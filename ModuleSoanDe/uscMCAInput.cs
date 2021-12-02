using System;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class uscMCAInput : UserControl
    {
        Question question;
        int selectedIndex = -1;


        public uscMCAInput()
        {
            InitializeComponent();
        }

        public uscMCAInput(Question q)
        {
            InitializeComponent();
            setQuestion(q);
        }

        public void setQuestion(Question q)
        {
            if(q is not null)
            {
                question = q;
                txtCorrectAnswer.Text = q.getCorrectAnswer();
                question.AnswerCollection.setDatasource(listBoxAnswers);
            }
        }

        public void lockUserControl()
        {
            txtAnswer.Enabled = false;
            btnAddA.Enabled = false;
            btnUpdateA.Enabled = false;
            btnDeleteA.Enabled = false;
            btnMakeCorrect.Enabled = false;
        }

        private void listBoxAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBoxAnswers.SelectedIndex;

            if(selectedIndex > -1)
            {
                txtAnswer.Text = question.AnswerCollection.getAnswer(selectedIndex);
                txtAnswer.Select();
            }
        }

        private void btnAddA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text))
            {
                question.AnswerCollection.addAnswer(new MultipleChoiceOption(txtAnswer.Text));
                txtAnswer.Text = String.Empty;
                listBoxAnswers.SelectedIndex = -1;
                txtAnswer.Select();
            }
        }

        private void btnUpdateA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text) && selectedIndex >= 0)
            {
                question.AnswerCollection.updateAnswer(txtAnswer.Text, selectedIndex);
            }
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text) && selectedIndex >= 0)
            {
                question.AnswerCollection.deleteAnswer(selectedIndex);

                if(selectedIndex == question.CorrectIndex)
                {
                    question.CorrectIndex = -1;
                    txtAnswer.Text = String.Empty; 
                }

                txtAnswer.Text = String.Empty;
                listBoxAnswers.SelectedIndex = -1;
            }
        }

        private void btnMakeCorrect_Click(object sender, EventArgs e)
        {
            if(selectedIndex >= 0)
            {
                question.CorrectIndex = selectedIndex;
                txtCorrectAnswer.Text = question.getCorrectAnswer();
            }
            else
                MessageBox.Show(
                   "Invalid option, please choose another answer",
                   "Warning!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }
    }
}
