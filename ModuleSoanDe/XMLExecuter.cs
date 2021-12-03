using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ModuleSoanDe
{
    public abstract class IXMLExecuter
    {
        protected static string dir = Environment.CurrentDirectory;
        protected static string projdir = Directory.GetParent(Directory.GetParent(dir).Parent.FullName).FullName;
        protected static string solutionDir = Directory.GetParent(projdir).FullName;

        protected static string bankDir = projdir + @"\bank\";
        protected static string answerDir = projdir + @"\answer\";
        protected static string resultDir = solutionDir + @"\result\";
        protected static string testDir = solutionDir + @"\test\";

        public abstract void writeQuestionCollection(QuestionCollection qc, string fileName);

        public abstract void readQuestionCollection(QuestionCollection qc, string fileName);

        protected static void addQCToDocument(XmlDocument doc, XmlElement ele, QuestionCollection qc, bool checkCorrect)
        {
            ele.SetAttribute("numberOfQuestion", $"{qc.Size}");

            int k = 0;
            foreach (var q in qc.ListOfQuestions)
            {
                XmlElement question = doc.CreateElement("question");

                question.SetAttribute("questionNumber", $"{k}");

                if(checkCorrect)
                {
                    question.SetAttribute("correctIndex", $"{q.CorrectIndex}");
                } 
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
                k++;
            }
        }
    }

    class NormalXMLExecuter : IXMLExecuter
    {
        private XmlDocument doc;

        private XmlElement storage;

        public NormalXMLExecuter()
        {
            doc = new XmlDocument();
            storage = doc.CreateElement("storage");
        }

        public override void writeQuestionCollection(QuestionCollection qc, string fileName)
        {
            if (qc.Size == 0)
                return;

            doc.AppendChild(storage);

            addQCToDocument(doc, storage, qc, true);

            fileName = bankDir + fileName;

            doc.Save(XmlWriter.Create(fileName, new XmlWriterSettings() { Indent = true }));
        }

        public override void readQuestionCollection(QuestionCollection qc, string fileName)
        {
            fileName = bankDir + fileName;
            using (var xml = XmlReader.Create(fileName))
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

    public class TestXMLExecuter : IXMLExecuter
    {
        private XmlDocument docTest;

        private XmlElement test;

        private XmlDocument docAnswer;

        private XmlElement answer;

        public TestXMLExecuter()
        {
            docTest = new XmlDocument();
            test = docTest.CreateElement("test");
            docTest.AppendChild(test);

            docAnswer = new XmlDocument();
            answer = docAnswer.CreateElement("answer");
            docAnswer.AppendChild(answer);
        }

        public override void writeQuestionCollection(QuestionCollection qc, string fileName)
        {
            if (qc.Size == 0)
                return;

            test.SetAttribute("id", $"{qc.Id}");
            test.SetAttribute("month", $"{qc.Month}");
            test.SetAttribute("year", $"{qc.Year}");

            addQCToDocument(docTest, test, qc, false);

            string testFileDir = testDir + "test-" + fileName;

            docTest.Save(XmlWriter.Create(testFileDir, new XmlWriterSettings() { Indent = true }));

            int i = 0;
            foreach(var q in qc.ListOfQuestions)
            {
                XmlElement question = docAnswer.CreateElement("question");
                question.SetAttribute("questionNumber", $"{i}");
                XmlElement correctAnswer = docAnswer.CreateElement("correctAnswer");
                correctAnswer.InnerText = q.CorrectIndex.ToString();
                question.AppendChild(correctAnswer);
                answer.AppendChild(question);
                i++;
            }

            string answerFileDir = answerDir + "answer-" + fileName;

            docAnswer.Save(XmlWriter.Create(answerFileDir, new XmlWriterSettings() { Indent = true }));

        }

        public override void readQuestionCollection(QuestionCollection qc, string fileName)
        {
            using (var xml = XmlReader.Create(fileName))
            {
                xml.ReadToFollowing("test");

                xml.MoveToAttribute("month");
                uint month = uint.Parse(xml.Value);
                xml.MoveToAttribute("year");
                uint year = uint.Parse(xml.Value);

                qc.transformToTest(month, year);

                xml.MoveToAttribute("numberOfQuestion");
                int n = int.Parse(xml.Value);

                for (int i = 0; i < n; i++)
                {
                    Question q = new Question();
                    xml.ReadToFollowing("question");

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

                    qc.addQuestion(q);
                }
            }
        }
    }


}
