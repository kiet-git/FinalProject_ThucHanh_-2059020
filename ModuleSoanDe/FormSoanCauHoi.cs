using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ModuleSoanDe
{
    public partial class FormSoanCauHoi : Form
    {
        BindingList<Question> listOfQuestions = new BindingList<Question>();

        int selectedIndex = -1;

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
            fsch.ShowDialog();
            listOfQuestions.ResetBindings();
            listBoxQuestions.SelectedIndex = -1;
        }

        private void btnUpdateQ_Click(object sender, EventArgs e)
        {
            if(selectedIndex > -1)
            {
                FormCauHoi fsch = new FormCauHoi(listOfQuestions[selectedIndex]);
                fsch.ShowDialog();
                listOfQuestions.ResetBindings();
            }
        }

        private void btnDeleteQ_Click(object sender, EventArgs e)
        {
            if(selectedIndex > -1)
            {
                listOfQuestions.RemoveAt(selectedIndex);
                listOfQuestions.ResetBindings();
                listBoxQuestions.SelectedIndex = -1;
            }
        }

        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listBoxQuestions.SelectedIndex;
        }

        private void writeToXML()
        {
            string filePath = @"\\Mac\Home\Desktop\FinalProject_ThucHanh_ 2059020\ModuleSoanDe\dataQuestion.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNode result = doc.DocumentElement;

            XmlElement user = doc.CreateElement("storage");
            user.SetAttribute("Number of question", $"{listOfQuestions.Count}");

            foreach(var q in listOfQuestions)
            {
                XmlElement question = doc.CreateElement("question");

                XmlElement category = doc.CreateElement("category");
                category.InnerText = q.Category.Title;

                XmlElement title = doc.CreateElement("title");
                title.InnerText = q.Title;

                XmlElement answer = doc.CreateElement("answer");
                foreach(var i in q.ListOfAnswers.ListOfAnswers)
                {
                    XmlElement option = doc.CreateElement("option");
                    option.InnerText = i.Answer;
                    answer.AppendChild(option);
                }

                question.AppendChild(category);
                question.AppendChild(title);
            }

          
            result.AppendChild(user);

            doc.Save(XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            writeToXML();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            writeToXML();
            this.Close();
        }
    }
}
