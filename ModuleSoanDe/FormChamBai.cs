using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ModuleSoanDe
{
    public partial class FormChamBai : Form
    {
        List<EmployeeTest> lstEmTest = new List<EmployeeTest>();
        List<Test> lstTest = new List<Test>();

        string selectedPath;
        string defaultOutputPath = @"\result.txt";

        public FormChamBai()
        {
            InitializeComponent();
            loadTestAnswer();
        }

        private void loadTestAnswer()
        {
            FormDirectory fd = new FormDirectory();

            string[] answerFiles = Directory.GetFiles(fd.getFolder("answerDir"));
            List<string> lstAnswerFiles = new List<string>(answerFiles);

            foreach (var file in lstAnswerFiles)
            {
                Test t = new Test();
                t.readCorrectXML(file);
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
                EmployeeTest et = new EmployeeTest();
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
                    if(emTest.CurrentTest.Id == test.Id)
                    {
                        emTest.Mark = test.Collection.markTest(emTest.CurrentTest.Collection);
                        MessageBox.Show(emTest.Mark.ToString(), test.Id);
                    }
                }
            }
        }

        private void writeToText()
        {
            lstEmTest.Sort(sortMark);
            NormalTextExecuter nre = new NormalTextExecuter();
            nre.write(lstEmTest, defaultOutputPath);
        }

        private int sortMark(EmployeeTest a, EmployeeTest b)
        {
            if (a.Mark > b.Mark)
                return -1;
            if (a.Mark < b.Mark)
                return 1;
            return 0;
        }
    }
}
