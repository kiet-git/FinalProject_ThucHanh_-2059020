using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleSoanDe;
using System.Windows.Forms;

namespace ModuleThiTN
{
    public partial class FormLamBai : Form
    {
        EmployeeTest currentTest;
        QuestionCollection testQuestion;

        public delegate void FormLamBai_ExitHandle();
        public event FormLamBai_ExitHandle FormLamBai_Exit;

        uscTestAnswer uta;
        Color red = Color.FromArgb(255, 127, 127);
        Color green = Color.FromArgb(144, 234, 144);
        Color black = Color.Black;

        string filePath;
        const int TIME_FOR_A_QUESTION = 15;
        bool outOfTime = false;

        public FormLamBai(EmployeeTest t)
        {
            InitializeComponent();

            currentTest = t;
            testQuestion = t.CurrentTest.Collection;

            lvwQuestion.Items.Clear();
            
            foreach(var q in testQuestion.LstQuestion)
            {
                ListViewItem lvi = new ListViewItem()
                {
                    Text = q.Title
                };
                lvi.BackColor = red;
                lvi.ForeColor = black;
                lvi.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lvwQuestion.Items.Add(lvi);
            }

            uta = new uscTestAnswer(testQuestion.getQuestion(0));
            uta.uscTestAnswer_Checked += new uscTestAnswer.uscTestAnswer_CheckedHandler(normalizeColor);
            uta.Location = new Point(250, 130);
            uta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(uta);

            lvwQuestion.SelectedIndices.Add(0);
            lbQuestion.Text = $"No. {1}: {testQuestion.getQuestion(0).Title}";

            int tempTime = TIME_FOR_A_QUESTION * testQuestion.Size; 

            uscClock1._mm = tempTime / 60;
            uscClock1._ss = tempTime % 60;
            uscClock1.Start();
            uscClock1.uscEClock_Exit += new uscClock.uscEClock_ExitHandle(uscClock1_Exit);
        }
        private void uscClock1_Exit()
        {
            uscClock1.Stop();
            outOfTime = true;

            MessageBox.Show(
                  "Your time is up! Please choose a folder to save your test",
                  "Information!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            openFolderDialogAndSave();

            this.Close();
        }

        private void normalizeColor()
        {
            if (lvwQuestion.SelectedIndices.Count > 0 && lvwQuestion.SelectedIndices[0] > -1)
            {
                if (testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]).isChosen())
                {
                    lvwQuestion.FocusedItem.BackColor = green;
                }
                else
                {
                    lvwQuestion.FocusedItem.BackColor = red;
                }
            }
        }

        private void lvwQuestion_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip questionMenu = new ContextMenuStrip();

            questionMenu.Items.Add("Highlight");
            questionMenu.Items.Add("Unhighlight");
            questionMenu.ItemClicked += new ToolStripItemClickedEventHandler(questionMenu_ItemClicked);

            if (e.Button == MouseButtons.Right)
            {
                var focused = lvwQuestion.FocusedItem;
                if(focused is not null)
                {
                    questionMenu.Show(Cursor.Position);
                }
            }
        }

        private void questionMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if(item.Text == "Highlight")
            {
                lvwQuestion.FocusedItem.BackColor = Color.Yellow;
            } else
            {
                normalizeColor();
            }
        }

        private void lvwQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwQuestion.SelectedIndices.Count > 0 && lvwQuestion.SelectedIndices[0] > -1)
            {
                lbQuestion.Text = $"No. {lvwQuestion.SelectedIndices[0] + 1}: {testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]).Title}";
                uta.setQuestion(testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]));
            }
        }

        private void FormLamBai_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLamBai_Exit();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (lvwQuestion.SelectedIndices[0] > 0)
            {
                int temp = lvwQuestion.SelectedIndices[0] - 1;
                lvwQuestion.SelectedIndices.Clear();
                lvwQuestion.SelectedIndices.Add(temp);
                lvwQuestion.FocusedItem = lvwQuestion.SelectedItems[0];
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lvwQuestion.SelectedIndices[0] < testQuestion.Size - 1)
            {
                int temp = lvwQuestion.SelectedIndices[0] + 1;
                lvwQuestion.SelectedIndices.Clear();
                lvwQuestion.SelectedIndices.Add(temp);
                lvwQuestion.FocusedItem = lvwQuestion.SelectedItems[0];
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            lvwQuestion.FocusedItem.BackColor = Color.Yellow;
        }

        private void btnUnhighlight_Click(object sender, EventArgs e)
        {
            normalizeColor();
        }

        private void openFolderDialogAndSave()
        {
            uscClock1.Stop();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filePath = fbd.SelectedPath + $"\\empTest-{currentTest.CurrentEm.Id}-{currentTest.CurrentTest.Id}.xml";
                saveTest();
            } else if (dr == DialogResult.Cancel)
            {
                MessageBox.Show(
                  "Please choose a folder to save your test",
                  "Information!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                openFolderDialogAndSave();
            }
        }

        private void FormLamBai_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(outOfTime)
            {
                openFolderDialogAndSave();
            } else
            {
                DialogResult dr = MessageBox.Show(
                  "Are you finished? Your test will be saved in your chosen folder. You cannot make change to the test if you choose yes.",
                  "Information!",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    openFolderDialogAndSave();
                } else
                {
                    e.Cancel = true;
                }
            }
        }

        private void saveTest()
        {
            currentTest.writeXML(filePath);
        }
    }
}
