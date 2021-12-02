using System;
using System.Windows.Forms;
using System.Xml;

namespace ModuleSoanDe
{
    public abstract class IXMLExecuter
    {
        public abstract void writeQuestionCollection(QuestionCollection qc, string filePath);

        public abstract void readQuestionCollection(QuestionCollection qc, string filePath);

        protected void addQCToDocument(XmlDocument doc, XmlElement ele, QuestionCollection qc)
        {
            ele.SetAttribute("numberOfQuestion", $"{qc.Size}");

            foreach (var q in qc.ListOfQuestions)
            {
                XmlElement question = doc.CreateElement("question");
                question.SetAttribute("correctIndex", $"{q.CorrectIndex}");
                question.SetAttribute("numberOfAnswer", $"{q.AnswerCollection.Size}");

                XmlElement category = doc.CreateElement("category");
                category.InnerText = q.Category.Title;

                XmlElement title = doc.CreateElement("title");
                title.InnerText = q.Title;

                XmlElement answer = doc.CreateElement("answer");
                foreach (var i in q.AnswerCollection.ListOfAnswers)
                {
                    XmlElement option = doc.CreateElement("option");
                    option.InnerText = i.Answer;
                    answer.AppendChild(option);
                }

                question.AppendChild(category);
                question.AppendChild(title);
                question.AppendChild(answer);
                ele.AppendChild(question);
            }
        }
    }

    class NormalXMLExecuter : IXMLExecuter
    {
        public override void writeQuestionCollection(QuestionCollection qc, string filePath)
        {
            if (qc.Size == 0)
                return;

            XmlDocument doc = new XmlDocument();
            
            XmlElement storage = doc.CreateElement("storage");
            doc.AppendChild(storage);

            base.addQCToDocument(doc, storage, qc);

            doc.Save(XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }));
        }

        public override void readQuestionCollection(QuestionCollection qc, string filePath)
        {
            using (var xml = XmlReader.Create(filePath))
            {
                xml.ReadToFollowing("storage");
                xml.MoveToAttribute("numberOfQuestion");
                int n = int.Parse(xml.Value);

                for(int i = 0; i < n; i++)
                {
                    Question q = new Question();
                    xml.ReadToFollowing("question");

                    xml.MoveToAttribute("correctIndex");
                    int temp = int.Parse(xml.Value);

                    xml.MoveToAttribute("numberOfAnswer");
                    int m = int.Parse(xml.Value);

                    xml.ReadToFollowing("category");
                    q.Category = new Category();
                    q.Category.Title = xml.ReadElementContentAsString();

                    xml.ReadToFollowing("title");
                    q.Title = xml.ReadElementContentAsString();

                    xml.ReadToFollowing("answer");
                    for (int j = 0; j < m; j++)
                    {
                        xml.ReadToFollowing("option");
                        MultipleChoiceOption mco = new MultipleChoiceOption(xml.ReadElementContentAsString());
                        q.AnswerCollection.addAnswer(mco);
                    }

                    q.CorrectIndex = temp;
                    qc.addQuestion(q);
                }
            }
        }
    }

    class TestXMLExecuter : IXMLExecuter
    {
        public override void writeQuestionCollection(QuestionCollection qc, string filePath)
        {
            if (qc.Size == 0)
                return;

            MessageBox.Show("yes");
            XmlDocument doc = new XmlDocument();

            XmlElement test = doc.CreateElement("test");
            doc.AppendChild(test);

            test.SetAttribute("id", $"{qc.Id}");
            test.SetAttribute("month", $"{qc.Month}");
            test.SetAttribute("year", $"{qc.Year}");

            base.addQCToDocument(doc, test, qc);

            doc.Save(XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }));
        }

        public override void readQuestionCollection(QuestionCollection qc, string filePath)
        {
            using (var xml = XmlReader.Create(filePath))
            {
                xml.ReadToFollowing("storage");
                xml.MoveToAttribute("numberOfQuestion");
                int n = int.Parse(xml.Value);

                for (int i = 0; i < n; i++)
                {
                    Question q = new Question();
                    xml.ReadToFollowing("question");

                    xml.MoveToAttribute("correctIndex");
                    int temp = int.Parse(xml.Value);

                    xml.MoveToAttribute("numberOfAnswer");
                    int m = int.Parse(xml.Value);

                    xml.ReadToFollowing("category");
                    q.Category = new Category();
                    q.Category.Title = xml.ReadElementContentAsString();

                    xml.ReadToFollowing("title");
                    q.Title = xml.ReadElementContentAsString();

                    xml.ReadToFollowing("answer");
                    for (int j = 0; j < m; j++)
                    {
                        xml.ReadToFollowing("option");
                        MultipleChoiceOption mco = new MultipleChoiceOption(xml.ReadElementContentAsString());
                        q.AnswerCollection.addAnswer(mco);
                    }

                    q.CorrectIndex = temp;
                    qc.addQuestion(q);
                }
            }
        }
    }


}
