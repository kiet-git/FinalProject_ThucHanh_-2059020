using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ModuleSoanDe
{
    public abstract class IXMLExecuter
    {
        protected FormDirectory fd = new FormDirectory();

        public abstract void writeQuestionCollection(QuestionCollection qc, string filePath);
        public abstract void readQuestionCollection(QuestionCollection qc, string filePath);

        protected static void addQCToDocument(XmlDocument doc, XmlElement ele, QuestionCollection qc, bool checkCorrect)
        {
            ele.SetAttribute("numberOfQuestion", $"{qc.Size}");

            int k = 0;
            foreach (var q in qc.LstQuestion)
            {
                XmlElement question = doc.CreateElement("question");

                question.SetAttribute("questionNumber", $"{k}");

                if (checkCorrect)
                {
                    question.SetAttribute("correctIndex", $"{q.CorrectIndex}");
                }
                question.SetAttribute("numberOfAnswer", $"{q.LstAnswerSize}");

                XmlElement category = doc.CreateElement("category");
                category.InnerText = q.Category.Title;

                XmlElement title = doc.CreateElement("title");
                title.InnerText = q.Title;

                XmlElement answer = doc.CreateElement("answer");
                foreach (var i in q.LstAnswer.LstOption)
                {
                    XmlElement option = doc.CreateElement("option");
                    option.InnerText = i.OptionName;
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

    public class NormalXMLExecuter : IXMLExecuter
    {
        private XmlDocument doc;

        private XmlElement storage;

        private string bankDir;

        public NormalXMLExecuter()
        {
            doc = new XmlDocument();
            storage = doc.CreateElement("storage");
            bankDir = fd.getFolder("bankDir");
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
                        Option mco = new Option(xml.ReadElementContentAsString());
                        q.addOption(mco);
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

        private string testDir;

        private string answerDir;

        private TestIdentification _td;

        public TestXMLExecuter(TestIdentification td)
        {
            _td = td;

            docTest = new XmlDocument();
            test = docTest.CreateElement("test");
            docTest.AppendChild(test);

            docAnswer = new XmlDocument();
            answer = docAnswer.CreateElement("answer");
            docAnswer.AppendChild(answer);

            testDir = fd.getFolder("testDir");
            answerDir = fd.getFolder("answerDir");
        }

        public override void writeQuestionCollection(QuestionCollection qc, string fileName)
        {
            if (qc.Size == 0)
                return;

            test.SetAttribute("id", $"{_td.Id}");
            test.SetAttribute("month", $"{_td.Month}");
            test.SetAttribute("year", $"{_td.Year}");

            addQCToDocument(docTest, test, qc, false);

            string testFileDir = testDir + "test-" + fileName;

            docTest.Save(XmlWriter.Create(testFileDir, new XmlWriterSettings() { Indent = true }));

            int i = 0;
            answer.SetAttribute("numberOfQuestion", $"{qc.Size}");
            foreach (var q in qc.LstQuestion)
            {
                XmlElement question = docAnswer.CreateElement("question");
                question.SetAttribute("questionNumber", $"{i}");

                XmlElement title = docAnswer.CreateElement("title");
                title.InnerText = q.Title;

                XmlElement correctAnswer = docAnswer.CreateElement("correctAnswer");
                correctAnswer.InnerText = q.CorrectIndex.ToString();

                question.AppendChild(title);
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
                _td.Month = uint.Parse(xml.Value);
                xml.MoveToAttribute("year");
                _td.Year = uint.Parse(xml.Value);

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
                        Option mco = new Option(xml.ReadElementContentAsString());
                        q.addOption(mco);
                    }

                    qc.addQuestion(q);
                }
            }
        }
        //    }
        //    public class EmployeeTestXMLExecuter : IXMLExecuter
        //    {
        //        private EmployeeTestQuestionCollection _emTestQC;

        //        private XmlDocument employeeTest;

        //        private XmlElement test;

        //        public EmployeeTestXMLExecuter(EmployeeTestQuestionCollection qc)
        //        {
        //            employeeTest = new XmlDocument();
        //            test = employeeTest.CreateElement("test");
        //            employeeTest.AppendChild(test);
        //            _emTestQC = qc;
        //        }

        //        public override void writeQuestionCollection(string fileName)
        //        {
        //            if (_emTestQC.Size == 0)
        //                return;
        //        }

        //        public override void readQuestionCollection(string fileName)
        //        {
        //            using (var xml = XmlReader.Create(fileName))
        //            {

        //            }
        //        }

        //    }
    }

    public class EmployeeTestXMLExecuter : IXMLExecuter
    {
        private XmlDocument docEmTest;

        private XmlElement test;

        private TestIdentification _td;

        private Employee _em;

        public EmployeeTestXMLExecuter(TestIdentification td, Employee e)
        {
            _td = td;
            _em = e;

            docEmTest = new XmlDocument();
            test = docEmTest.CreateElement("test");
            docEmTest.AppendChild(test);
        }

        public override void writeQuestionCollection(QuestionCollection qc, string filePath)
        {
            if (qc.Size == 0)
                return;

            test.SetAttribute("id", $"{_td.Id}");
            test.SetAttribute("month", $"{_td.Month}");
            test.SetAttribute("year", $"{_td.Year}");

            XmlElement employee = docEmTest.CreateElement("employee");
            employee.SetAttribute("emId", _em.Id);
            employee.SetAttribute("emName", _em.Name);
            employee.SetAttribute("emEmail", _em.Email);
            test.AppendChild(employee);

            int i = 0;
            foreach (var q in qc.LstQuestion)
            {
                XmlElement question = docEmTest.CreateElement("question");
                question.SetAttribute("questionNumber", $"{i}");

                XmlElement title = docEmTest.CreateElement("title");
                title.InnerText = q.Title;

                XmlElement chosenAnswer = docEmTest.CreateElement("chosenAnswer");
                chosenAnswer.InnerText = q.ChosenIndex.ToString();

                question.AppendChild(title);
                question.AppendChild(chosenAnswer);
                test.AppendChild(question);
                i++;
            }

            docEmTest.Save(XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }));
        }

        public override void readQuestionCollection(QuestionCollection qc, string filePath)
        {

        }

    }
}
