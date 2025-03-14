﻿using System;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class FormTaoDe : Form
    {
        string defaultInputFile = @"dataQuestion.xml";

        NormalQCollection quesColInput = new NormalQCollection();
        TestQCollection quesColOutput = new TestQCollection();

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

            quesColOutput.LstQuestion = quesColInput.randomizeQuestionToTest(noOfQ);
            quesColOutput.setDatasource(listBoxQOut);
            isSaved = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if(listBoxQIn.SelectedIndex > -1)
            {
                quesColInput.viewQuestionInFormCauHoi(listBoxQIn.SelectedIndex);
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

            quesColOutput.Month = month;
            quesColOutput.Year = year;
            quesColOutput.writeXML("");

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
            } else
            {
                DialogResult dr2 = MessageBox.Show(
                     "Do you want to quit?",
                     "Information!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information);
                if(dr2 == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
