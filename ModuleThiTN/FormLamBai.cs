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

        uscTestAnswer uta;

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
                lvwQuestion.Items.Add(lvi);
            }

            lvwQuestion.SelectedIndices.Add(0);
            uta = new uscTestAnswer(testQuestion.getQuestion(0));
            uta.Location = new Point(259, 137);
            uta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(uta);
        }

        private void lvwQuestion_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip questionMenu = new ContextMenuStrip();

            questionMenu.Items.Add("Highlight");
            questionMenu.Items.Add("Unhighlight");

            if (e.Button == MouseButtons.Right)
            {
                var focused = lvwQuestion.FocusedItem;
                if(focused is not null)
                {
                    questionMenu.Show(Cursor.Position);
                }
            }
        }

        private void lvwQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwQuestion.SelectedIndices.Count > 0 && lvwQuestion.SelectedIndices[0] > -1)
            {
                uta.setQuestion(testQuestion.getQuestion(lvwQuestion.SelectedIndices[0]));
            }
        }
    }
}
