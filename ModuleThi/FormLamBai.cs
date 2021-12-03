using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModuleSoanDe;

namespace ModuleThi
{
    public partial class FormLamBai : Form
    {
        QuestionCollection testQuestion;
        Test currentTest;

        public FormLamBai(QuestionCollection qc, Test t)
        {
            InitializeComponent();
            testQuestion = qc;
            currentTest = t;
        }
    }
}
