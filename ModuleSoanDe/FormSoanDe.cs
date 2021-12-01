using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
