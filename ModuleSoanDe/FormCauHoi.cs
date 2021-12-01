using System;
using System.Windows.Forms;
using System.Drawing;

namespace ModuleSoanDe
{
    public partial class FormCauHoi : Form
    {
        public delegate void FormCauHoi_ExitHandle();
        public event FormCauHoi_ExitHandle FormCauHoi_Exit;

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

        private bool saveData()
        {
            if (cmbxCategory.SelectedIndex < 0
               || String.IsNullOrEmpty(txtQuestion.Text)
               || question.Answers.checkEmpty()
               || question.CorrectIndex < 0)
            {
                MessageBox.Show(
                    "Field Empty! Please enter data for all fields",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            question.Category = new Category()
            {
                Title = cmbxCategory.SelectedItem.ToString()
            };

            question.Title = txtQuestion.Text;

            MessageBox.Show(
              "Your question is saved successfully",
              "Information!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!saveData())
            {
                DialogResult dr = MessageBox.Show("Do you want to quit? Your data will not be saved.", 
                    "Information!", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    FormCauHoi_Exit();
                    this.Close();
                }
            } else
            {
                this.Close();
            }
        }
    }
}
