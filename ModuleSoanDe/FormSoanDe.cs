using System;
using System.IO;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class FormSoanDe : Form
    {
        public FormSoanDe()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormSoanCauHoi fsch = new FormSoanCauHoi();
            fsch.ShowDialog();
        }

        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            FormTaoDe ftd = new FormTaoDe();
            ftd.ShowDialog();
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            FormChamBai fcb = new FormChamBai();
            fcb.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
