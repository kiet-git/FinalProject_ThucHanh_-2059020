using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace ModuleSoanDe
{
    public partial class FormSoanCauHoi : Form
    {
        BindingList<Question> listOfQuestions = new BindingList<Question>();

        int selectedIndex = -1;
        bool isSaved = false;

        public FormSoanCauHoi()
        {
            InitializeComponent();
            listBoxQuestions.DataSource = listOfQuestions;
        }

        private void btnAddQ_Click(object sender, EventArgs e)
        {
            Question q = new Question();
            listOfQuestions.Add(q);
            FormCauHoi fsch = new FormCauHoi(q);
            fsch.FormCauHoi_Exit += new FormCauHoi.FormCauHoi_ExitHandle(formCauHoi_Exit);
            fsch.ShowDialog();
            listOfQuestions.ResetBindings();
            listBoxQuestions.SelectedIndex = -1;
            isSaved = false;
        }

        private void btnUpdateQ_Click(object sender, EventArgs e)
        {
            if(selectedIndex > -1)
            {
                FormCauHoi fsch = new FormCauHoi(listOfQuestions[selectedIndex]);
                fsch.ShowDialog();
                listOfQuestions.ResetBindings();
                isSaved = false;
            }
        }

        private void btnDeleteQ_Click(object sender, EventArgs e)
        {
            if(selectedIndex > -1)
            {
                listOfQuestions.RemoveAt(selectedIndex);
                listOfQuestions.ResetBindings();
                listBoxQuestions.SelectedIndex = -1;
                isSaved = false;
            }
        }

        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBoxQuestions.SelectedIndex;
        }

        void formCauHoi_Exit()
        {
            listOfQuestions.RemoveAt(listOfQuestions.Count - 1);
        }

        private void writeToXML()
        {
            if (listOfQuestions.Count == 0)
                return;

            string filePath = @"\\Mac\Home\Desktop\FinalProject_ThucHanh_ 2059020\ModuleSoanDe\dataQuestion.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlElement storage = doc.DocumentElement;
            if (storage is null)
                storage = doc.CreateElement("storage");
            storage.SetAttribute("numberOfQuestion", $"{int.Parse(storage.GetAttribute("numberOfQuestion")) + listOfQuestions.Count}");

            foreach(var q in listOfQuestions)
            {
                XmlElement question = doc.CreateElement("question");
                question.SetAttribute("correctIndex", $"{q.CorrectIndex}");
                question.SetAttribute("numberOfAnswer", $"{q.Answers.getListCount()}");

                XmlElement category = doc.CreateElement("category");
                category.InnerText = q.Category.Title;

                XmlElement title = doc.CreateElement("title");
                title.InnerText = q.Title;

                XmlElement answer = doc.CreateElement("answer");
                foreach(var i in q.Answers.ListOfAnswers)
                {
                    XmlElement option = doc.CreateElement("option");
                    option.InnerText = i.Answer;
                    answer.AppendChild(option);
                }

                question.AppendChild(category);
                question.AppendChild(title);
                question.AppendChild(answer);
                storage.AppendChild(question);
            }

            doc.Save(XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }));
            MessageBox.Show(
                 "Your data is saved successfully",
                 "Information!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isSaved)
                writeToXML();
            isSaved = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(!isSaved)
                writeToXML();
            this.Close();
        }
    }
}
