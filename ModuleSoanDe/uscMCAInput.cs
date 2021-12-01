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
                listBoxAnswers.DataSource = question.Answers.ListOfAnswers;
            }
        }

        private void listBoxAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBoxAnswers.SelectedIndex;

            if(selectedIndex > -1)
                txtAnswer.Text = question.Answers.getAnswer(selectedIndex).ToString();
        }

        private void btnAddA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text))
            {
                question.Answers.addAnswer(new MultipleChoiceOption(txtAnswer.Text));
                txtAnswer.Text = "";
                listBoxAnswers.SelectedIndex = -1;
            }
        }

        private void btnUpdateA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text) && selectedIndex >= 0)
            {
                question.Answers.updateAnswer(txtAnswer.Text, selectedIndex);
            }
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text) && selectedIndex >= 0)
            {
                question.Answers.deleteAnswer(selectedIndex);
                txtAnswer.Text = "";
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
