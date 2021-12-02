using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class FormTaoDe : Form
    {
        string filePath = @"\\Mac\Home\Desktop\FinalProject_ThucHanh_ 2059020\ModuleSoanDe\dataQuestion.xml";
        string filePath1 = @"\\Mac\Home\Desktop\FinalProject_ThucHanh_ 2059020\ModuleSoanDe\dataTest.xml";

        QuestionCollection quesColInput = new QuestionCollection(new NormalXMLExecuter());
        QuestionCollection quesColOutput = new QuestionCollection(new TestXMLExecuter());

        public FormTaoDe()
        {
            InitializeComponent();
            quesColInput.setDatasource(listBoxQIn);
            quesColOutput.setDatasource(listBoxQOut);
        }

        private void FormTaoDe_Load(object sender, EventArgs e)
        {
            quesColInput.readXML(filePath);
            txtAvailable.Text = quesColInput.Size.ToString();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int noOfQ;
            bool check = int.TryParse(txtNofQ.Text, out noOfQ);

            if (!check || noOfQ <= 0 || noOfQ > quesColInput.Size)
            {
                return;
            }

            quesColOutput = quesColInput.randomizeQuestion(noOfQ);
            quesColOutput.setDatasource(listBoxQOut);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if(listBoxQIn.SelectedIndex > -1)
            {
                quesColInput.viewQuestion(listBoxQIn.SelectedIndex);
            }
        }

        private void btnAddQ_Click(object sender, EventArgs e)
        {
            if (listBoxQIn.SelectedIndex > -1)
            {
                Question q = quesColInput.getQuestion(listBoxQIn.SelectedIndex);
                if (listBoxQIn.SelectedIndex > -1
                    && quesColOutput.checkEqual(q))
                {
                    quesColOutput.addQuestion(q);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxQIn.SelectedIndex > -1)
            {
                quesColOutput.deleteQuestion(listBoxQOut.SelectedIndex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listBoxQIn.SelectedIndex > -1)
            {
                quesColOutput.clearQuestion();
            }
        }

        private void writeToXML()
        {
            uint month;
            uint year;

            bool check1 = uint.TryParse(txtMonth.Text, out month);
            bool check2 = uint.TryParse(txtYear.Text, out year);

            if (!check1 || !check2 
                || quesColOutput.Size == 0 
                || month < 1 || month > 12 || year < 1)
                return;

            quesColOutput.transformToTest(month, year);
            quesColOutput.XMLExecuter = new TestXMLExecuter();
            quesColOutput.writeToXML(filePath1);

            MessageBox.Show(
                 "Your data is saved successfully",
                 "Information!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            writeToXML();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
               "Do you want to save your data?",
               "Information!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                writeToXML();
            }

            this.Close();
        }
    }
}
