using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class FormTaoDe : Form
    {
        string defaultInputFile = @"dataQuestion.xml";
        string defaultOutputFile = @"dataTest.xml"; //test-{id}

        QuestionCollection quesColInput = new QuestionCollection(new NormalXMLExecuter());
        QuestionCollection quesColOutput = new QuestionCollection(new TestXMLExecuter());

        bool isSaved = true;

        public FormTaoDe()
        {
            InitializeComponent();
            quesColInput.setDatasource(listBoxQIn);
            quesColOutput.setDatasource(listBoxQOut);
        }

        private void FormTaoDe_Load(object sender, EventArgs e)
        {
            quesColInput.readXML(defaultInputFile);
            txtAvailable.Text = quesColInput.Size.ToString();
            MessageBox.Show(
                "Test will be stored int the test file of the solution. Answer for the test will be stored in the answer file of the project. Id of the files is the month and year combination.",
                "Information!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
            isSaved = false;
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
                    && !quesColOutput.checkEqual(q))
                {
                    quesColOutput.addQuestion(q);
                    isSaved = false;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxQIn.SelectedIndex > -1)
            {
                quesColOutput.deleteQuestion(listBoxQOut.SelectedIndex);
                isSaved = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listBoxQIn.SelectedIndex > -1)
            {
                quesColOutput.clearQuestion();
                isSaved = false;
            }
        }

        private void writeToXML()
        {
            uint month;
            uint year;

            bool check1 = uint.TryParse(txtMonth.Text, out month);
            bool check2 = uint.TryParse(txtYear.Text, out year);

            if(!check1 || month < 1 || month > 12)
            {
                MessageBox.Show(
                 "Month is not appropriate",
                 "Warning!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            if(!check2 || year < 1)
            {
                MessageBox.Show(
                 "Year is not appropriate",
                 "Warning!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            if (isSaved || quesColOutput.Size == 0)
                return;

            quesColOutput.transformToTest(month, year);
            defaultOutputFile = quesColOutput.Id + ".xml";

            quesColOutput.writeToXML(defaultOutputFile);

            MessageBox.Show(
                 "Your data is saved successfully",
                 "Information!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
            
            isSaved = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            writeToXML();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTaoDe_FormClosing(object sender, FormClosingEventArgs e)
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
        }
    }
}
