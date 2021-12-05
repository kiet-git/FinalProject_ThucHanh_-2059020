using System;
using System.Windows.Forms;
using ModuleSoanDe;

namespace ModuleThiTN
{
    public partial class FormThi : Form
    {
        Test test = new Test();
        string filePath;

        EmployeeTest currentTest;

        public FormThi()
        {
            InitializeComponent();
        }

        private void btnChooseTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lbFilePath.Text = "File name: " + dialog.FileName;
                filePath = dialog.FileName;
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(filePath))
            { 
                MessageBox.Show("Test file is missing! Please choose the file containing the test",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string[] checkPath = filePath.Split("-");
            if(checkPath[0] != "test" || checkPath.Length != 3)
            {
                MessageBox.Show("Test file is inappropriate! Please choose the file containing the test",
                   "Warning",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            test.readXML(filePath);
             
            if (test.Size == 0
                || String.IsNullOrEmpty(txtId.Text)
                || String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtEmail.Text)
                || txtEmail.Text.Split('@').Length != 2)
            {
                MessageBox.Show("A field is missing or incorrect! Please ensure all fields are filled correctly",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            currentTest = new EmployeeTest(new Employee(txtId.Text, txtName.Text, txtEmail.Text), test);
            FormLamBai flb = new FormLamBai(currentTest);
            flb.FormLamBai_Exit += new FormLamBai.FormLamBai_ExitHandle(closeCurrent);
            this.Hide();
            flb.Show();
        }

        private void closeCurrent()
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
