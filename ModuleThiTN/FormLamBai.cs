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
        QuestionCollection testQuestion;
        Test currentTest;

        public delegate void FormLamBai_ExitHandle();
        public event FormLamBai_ExitHandle FormLamBai_Exit;

        uscTestAnswer uta;
        Color red = Color.FromArgb(255, 127, 127);
        Color green = Color.FromArgb(144, 234, 144);
        Color black = Color.Black;

        public FormLamBai(QuestionCollection qc, Test t)
        {
            InitializeComponent();
            testQuestion = qc;
            currentTest = t;
            lvwQuestion.Items.Clear();
            
            foreach(var q in testQuestion.ListOfQuestions)
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

            lvwQuestion.SelectedIndices.Add(0);
            lbQuestion.Text = $"No. {1}: {testQuestion.getQuestion(0).Title}";

            uta = new uscTestAnswer(testQuestion.getQuestion(0));
            uta.uscTestAnswer_Checked += new uscTestAnswer.uscTestAnswer_CheckedHandler(changeColor);
            uta.Location = new Point(250, 130);
            uta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(uta);
        }

        private void changeColor()
        {
            if (lvwQuestion.SelectedIndices.Count > 0 && lvwQuestion.SelectedIndices[0] > -1)
            {
                lvwQuestion.Items[lvwQuestion.SelectedIndices[0]].BackColor = green;
                lvwQuestion.Items[lvwQuestion.SelectedIndices[0]].ForeColor = black;
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
                if(testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]).isChosen())
                {
                    lvwQuestion.FocusedItem.BackColor = green;
                } else
                {
                    lvwQuestion.FocusedItem.BackColor = red;
                }
            }
        }

        private void lvwQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwQuestion.SelectedIndices.Count > 0 && lvwQuestion.SelectedIndices[0] > -1)
            {
               
                lbQuestion.Text = $"No. {lvwQuestion.SelectedIndices[0] + 1}: {testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]).Title}";
                uta.setQuestion(testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]));
            }
        }


        private void FormLamBai_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLamBai_Exit();
        }

        private void FormLamBai_Load(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (lvwQuestion.SelectedIndices[0] > 0)
            {
                int temp = lvwQuestion.SelectedIndices[0] - 1;
                lvwQuestion.SelectedIndices.Clear();
                lvwQuestion.SelectedIndices.Add(temp);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lvwQuestion.SelectedIndices[0] < testQuestion.Size - 1)
            {
                int temp = lvwQuestion.SelectedIndices[0] + 1;
                lvwQuestion.SelectedIndices.Clear();
                lvwQuestion.SelectedIndices.Add(temp);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Finish!");
            this.Close();
        }
    }
}
