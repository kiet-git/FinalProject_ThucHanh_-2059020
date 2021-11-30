using System;
using System.Windows.Forms;
using System.Drawing;

namespace ModuleSoanDe
{
    internal partial class FormCauHoi : Form
    {
        Question question;

        public FormCauHoi(Question q)
        {
            InitializeComponent();
            if (q is null)
            {
                q = new Question();
            }
            question = q;
            cmbxCategory.DataSource = question.Category.PotentialValue;
            cmbxCategory.SelectedItem = question.Category.Title;
            txtQuestion.Text = question.Title;
            txtQuestion.Select();
        }

        private void FormCauHoi_Load(object sender, EventArgs e)
        {
            uscMCAInput uscInputAnswer = new uscMCAInput(question);
            uscInputAnswer.Location = new Point(13, 130);
            this.Controls.Add(uscInputAnswer);
        }

        private void saveData()
        {
            if (cmbxCategory.SelectedIndex < 0
               || String.IsNullOrEmpty(txtQuestion.Text)
               || question.ListOfAnswers.checkEmpty())
            {
                MessageBox.Show(
                    "Field Empty! Please enter data for all fields",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            question.Category = new Category()
            {
                Title = cmbxCategory.SelectedItem.ToString()
            };

            question.Title = txtQuestion.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            saveData();
            this.Close();
        }
    }
}
