using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ModuleSoanDe
{
    public partial class FormChamBai : Form
    {
        List<EmTestQCollection> lstEmTest = new List<EmTestQCollection>();
        List<TestQCollection> lstTest = new List<TestQCollection>();

        string selectedPath;
        string defaultOutputPath = @"result.txt";

        public FormChamBai()
        {
            InitializeComponent();
            loadTestAnswer();
        }

        private void loadTestAnswer()
        {
            ProjectDirectory fd = new ProjectDirectory();

            string[] answerFiles = Directory.GetFiles(fd.getFolder("answerDir"));
            List<string> lstAnswerFiles = new List<string>(answerFiles);

            foreach (var file in lstAnswerFiles)
            {
                TestQCollection t = new TestQCollection();
                t.XMLExecuter = new CorrectAnswerXMLExecuter(t);
                t.readXML(file);
                lstTest.Add(t);
            }
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                selectedPath = fbd.SelectedPath;
            }

            if (selectedPath is null)
                return;

            string[] files = Directory.GetFiles(selectedPath);
            List<string> lstFiles = new List<string>(files);
            for(int i = 0; i < lstFiles.Count; i++)
            {
                if(!lstFiles[i].Contains(".xml") || !lstFiles[i].Contains("empTest"))
                {
                    lstFiles.RemoveAt(i);
                }
            }

            if (lstFiles.Count < 1)
                return;

            foreach(var file in lstFiles)
            {
                EmTestQCollection et = new EmTestQCollection();
                et.readXML(file);
                lstEmTest.Add(et);
            }

            markTest();

            if(!String.IsNullOrEmpty(txtFileName.Text))
            {
                defaultOutputPath = txtFileName.Text + ".txt";
            }
            writeToText();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void markTest()
        {
            foreach(var emTest in lstEmTest)
            {
                foreach(var test in lstTest)
                {
                    if(emTest.Id == test.Id)
                    {
                        emTest.Mark = test.markTest(emTest);
                        double temp = (double)emTest.Mark / emTest.Size * 10.0;
                        emTest.Mark = (int)Math.Round(temp);
                    }
                }
            }
        }

        private void writeToText()
        {
            lstEmTest.Sort(sortMark);
            NormalTextExecuter nre = new NormalTextExecuter();
            nre.write(lstEmTest, defaultOutputPath);

            MessageBox.Show("Your mark is successfully saved in the designated directory!",
                "Information!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private int sortMark(EmTestQCollection a, EmTestQCollection b)
        {
            if (a.Mark > b.Mark)
                return -1;
            if (a.Mark < b.Mark)
                return 1;
            return 0;
        }
    }
}
