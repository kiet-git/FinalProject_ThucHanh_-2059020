using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace ModuleSoanDe
{
    public partial class FormValidation : Form
    {
        const string FILE_NAME = @"\user.json";
        List<User> lstUsers;

        public FormValidation()
        {
            InitializeComponent();
            loadJSON();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validateUser();
        }

        private void validateUser()
        {
            if (!checkCredential())
            {
                MessageBox.Show("Wrong credential! Please check again!",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Login sucessfully!",
                   "Information!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

            FormSoanDe fsd = new FormSoanDe();
            this.Hide();
            fsd.ShowDialog();
            this.Close();
        }

        private void loadJSON()
        {
            ProjectDirectory fd = new ProjectDirectory();
            string content = File.ReadAllText(fd.getFolder("credentialDir") + FILE_NAME);
            lstUsers = JsonSerializer.Deserialize<List<User>>(content);
        }

        private bool checkCredential()
        {
            return lstUsers.Find(user =>
            {
                return user.Username == txtUsername.Text && user.Password == txtPassword.Text;
            }) is not null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                validateUser();
            }
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
