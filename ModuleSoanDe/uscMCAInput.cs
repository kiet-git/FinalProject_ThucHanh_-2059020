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
                listBoxAnswers.DataSource = question.ListOfAnswers.ListOfAnswers;
            }
        }

        private void listBoxAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBoxAnswers.SelectedIndex;

            if(selectedIndex > -1)
                txtAnswer.Text = question.ListOfAnswers.getAnswer(selectedIndex).ToString();
        }

        private void btnAddA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text))
            {
                question.ListOfAnswers.addAnswer(new MultipleChoiceOption(txtAnswer.Text));
                txtAnswer.Text = "";
                listBoxAnswers.SelectedIndex = -1;
            }
        }

        private void btnUpdateA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text) && selectedIndex >= 0)
            {
                question.ListOfAnswers.updateAnswer(txtAnswer.Text, selectedIndex);
            }
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAnswer.Text) && selectedIndex >= 0)
            {
                question.ListOfAnswers.deleteAnswer(selectedIndex);
                txtAnswer.Text = "";
                listBoxAnswers.SelectedIndex = -1;
            }
        }
    }
}
