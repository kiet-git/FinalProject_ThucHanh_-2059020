using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ModuleSoanDe
{
    public abstract class IXMLExecuter
    {
        protected ProjectDirectory fd = new ProjectDirectory();

        private protected XMLRootHandler xmlRootHandler;

        private protected XMLQuestionNodeHandler xmlQuestionNodeHandler;

        private protected XMLCategoryAndTitleHandler xmlCategoryAndTitleHandler = new XMLCategoryAndTitleHandler();

        private protected XMLChosenCorrectHandler xmlChosenCorrectHandler;

        private protected XMLAnswerHandler xmlAnswerHandler = new XMLAnswerHandler();

        protected void writeTemplate(string filePath, string root, bool hasChosenOrCorrect, bool hasAnswer, IQCollection qc)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement storage = xmlRootHandler.write(doc, root);
            for (int i = 0; i < qc.Size; i++)
            {
                Question q = qc.getQuestion(i);
                XmlElement question = xmlQuestionNodeHandler.write(doc, storage, i, q);
                xmlCategoryAndTitleHandler.write(doc, question, q);
                if(hasChosenOrCorrect)
                {
                    xmlChosenCorrectHandler.write(doc, question, q);
                }
                if(hasAnswer)
                {
                    xmlAnswerHandler.write(doc, question, q);
                }
            }

            doc.Save(XmlWriter.Create(filePath, new XmlWriterSettings() { Indent = true }));
        }

        protected void readTemplate(string filePath, string root, bool hasChosenOrCorrect, bool hasAnswer, IQCollection qc)
        {
            using (var xml = XmlReader.Create(filePath))
            {
                int n = xmlRootHandler.read(xml, root);

                for (int i = 0; i < n; i++)
                {
                    Question q = new Question();

                    int m = xmlQuestionNodeHandler.read(xml);
                    xmlCategoryAndTitleHandler.read(xml, q);
                    if(hasChosenOrCorrect)
                    {
                        xmlChosenCorrectHandler.read(xml, q);
                    }
                    if(hasAnswer)
                    {
                        xmlAnswerHandler.read(xml, q, m);
                    }

                    qc.addQuestion(q);
                }
            }
        }

        public abstract void write(string filePath);
        public abstract void read(string filePath);
    }

    public class NormalXMLExecuter : IXMLExecuter
    {
        private string bankDir;

        private NormalQCollection _normalCollection;

        private const string ROOT_NAME = "storage";

        public NormalXMLExecuter(NormalQCollection qc)
        {
            _normalCollection = qc;

            bankDir = fd.getFolder("bankDir");

            xmlRootHandler = new XMLNormalRootHandler(_normalCollection);
            xmlQuestionNodeHandler = new XMLWithAnswerQNodeHandler();
            xmlChosenCorrectHandler = new XMLCorrectIndexHandler();
        }

        public override void write(string fileName)
        {
            if (_normalCollection.Size == 0)
                return;

            fileName = bankDir + fileName;
            writeTemplate(fileName, ROOT_NAME, true, true, _normalCollection);
        }


        public override void read(string fileName)
        {
            fileName = bankDir + fileName;
            readTemplate(fileName, ROOT_NAME, true, true, _normalCollection);
        }
    }

    public class TestXMLExecuter : IXMLExecuter
    {
        private string testDir;

        private TestQCollection _testCollection;

        private const string ROOT_NAME = "test";

        public TestXMLExecuter(TestQCollection qc)
        {
            _testCollection = qc;

            xmlRootHandler = new XMLTestRootHandler(_testCollection);
            xmlQuestionNodeHandler = new XMLWithAnswerQNodeHandler();

            testDir = fd.getFolder("testDir");
        }

        public override void write(string fileName)
        {
            if (_testCollection.Size == 0)
                return;

            string testFileDir = testDir + "test-" + fileName;

            writeTemplate(testFileDir, ROOT_NAME, false, true, _testCollection);
            
            _testCollection.XMLExecuter = new CorrectAnswerXMLExecuter(_testCollection);
            _testCollection.writeXML(fileName);
        }

        public override void read(string fileName)
        {
            readTemplate(fileName, ROOT_NAME, false, true, _testCollection);
        }
    }

    public class EmployeeTestXMLExecuter : IXMLExecuter
    {
        private EmTestQCollection _emTestCollection;

        private const string ROOT_NAME = "test";

        public EmployeeTestXMLExecuter(EmTestQCollection qc)
        {
            _emTestCollection = qc;

            xmlRootHandler = new XMLEmTestRootHandler(_emTestCollection);
            xmlQuestionNodeHandler = new XMLQuestionNodeHandler();
            xmlChosenCorrectHandler = new XMLChosenIndexHandler();
        }

        public override void write(string filePath)
        {
            if (_emTestCollection.Size == 0)
                return;

            writeTemplate(filePath, ROOT_NAME, true, false, _emTestCollection);
        }

        public override void read(string filePath)
        {
            readTemplate(filePath, ROOT_NAME, true, false, _emTestCollection);
        }

    }

    public class CorrectAnswerXMLExecuter : IXMLExecuter
    {
        private TestQCollection _testCollection;

        private string answerDir;

        private const string ROOT_NAME = "answer";

        public CorrectAnswerXMLExecuter(TestQCollection qc)
        {
            _testCollection = qc;

            xmlRootHandler = new XMLTestRootHandler(_testCollection);
            xmlQuestionNodeHandler = new XMLQuestionNodeHandler();
            xmlChosenCorrectHandler = new XMLCorrectIndexHandler();

            answerDir = fd.getFolder("answerDir");
        }

        public override void write(string fileName)
        {
            string answerFileDir = answerDir + "answer-" + fileName;

            writeTemplate(answerFileDir, ROOT_NAME, true, false, _testCollection);
        }
        public override void read(string filePath)
        {
            readTemplate(filePath, ROOT_NAME, true, false, _testCollection);
        }
    }

    //1
    interface XMLRootHandler
    {
        XmlElement write(XmlDocument doc, string name);

        int read(XmlReader xml, string name);
    }
    class XMLNormalRootHandler : XMLRootHandler
    {
        NormalQCollection _normalCollection;

        public XMLNormalRootHandler(NormalQCollection qc)
        {
            _normalCollection = qc;
        } 

        public XmlElement write(XmlDocument doc, string name)
        {
            XmlElement ele = doc.CreateElement(name);
            ele.SetAttribute("numberOfQuestion", $"{_normalCollection.Size}");
            doc.AppendChild(ele);
            return ele;
        }

        public int read(XmlReader xml, string name)
        {
            xml.ReadToFollowing(name);
            xml.MoveToAttribute("numberOfQuestion");
            return int.Parse(xml.Value); ;
        }
    }
    class XMLTestRootHandler : XMLRootHandler
    {
        TestQCollection _testCollection;

        public XMLTestRootHandler(TestQCollection qc)
        {
            _testCollection = qc;
        }

        public virtual XmlElement write(XmlDocument doc, string name)
        {
            XmlElement ele = doc.CreateElement(name);
            ele.SetAttribute("id", $"{_testCollection.Id}");
            ele.SetAttribute("month", $"{_testCollection.Month}");
            ele.SetAttribute("year", $"{_testCollection.Year}");
            ele.SetAttribute("numberOfQuestion", $"{_testCollection.Size}");
            doc.AppendChild(ele);
            return ele;
        }
        public virtual int read(XmlReader xml, string name)
        {
            xml.ReadToFollowing(name);

            xml.MoveToAttribute("month");
            _testCollection.Month = uint.Parse(xml.Value);
            xml.MoveToAttribute("year");
            _testCollection.Year = uint.Parse(xml.Value);

            xml.MoveToAttribute("numberOfQuestion");
            return int.Parse(xml.Value);
        }
    }
    class XMLEmTestRootHandler : XMLTestRootHandler
    {
        EmTestQCollection _emTestCollection;

        public XMLEmTestRootHandler(EmTestQCollection qc) : base(qc)
        {
            _emTestCollection = qc;
        }

        public override XmlElement write(XmlDocument doc, string name)
        {
            XmlElement ele = base.write(doc, name);
            XmlElement employee = doc.CreateElement("employee");
            employee.SetAttribute("emId", _emTestCollection.EmId);
            employee.SetAttribute("emName", _emTestCollection.EmName);
            employee.SetAttribute("emEmail", _emTestCollection.EmEmail);
            ele.AppendChild(employee);
            return ele;
        }

        public override int read(XmlReader xml, string name)
        {
            int n = base.read(xml, name);

            xml.ReadToFollowing("employee");
            xml.MoveToAttribute("emId");
            _emTestCollection.EmId = xml.Value;
            xml.MoveToAttribute("emName");
            _emTestCollection.EmName = xml.Value;
            xml.MoveToAttribute("emEmail");
            _emTestCollection.EmEmail = xml.Value;

            return n;
        }


    }
    //2
    class XMLQuestionNodeHandler
    {
        public virtual XmlElement write(XmlDocument doc, XmlElement ele, int n, Question q)
        {
            XmlElement question = doc.CreateElement("question");
            question.SetAttribute("questionNumber", $"{n}");
            ele.AppendChild(question);
            return question;
        }

        public virtual int read(XmlReader xml) {
            return 0;
        }
    }
    class XMLWithAnswerQNodeHandler : XMLQuestionNodeHandler
    {
        public override XmlElement write(XmlDocument doc, XmlElement ele, int n, Question q)
        {
            XmlElement question = base.write(doc, ele, n, q);
            question.SetAttribute("numberOfAnswer", $"{q.LstAnswerSize}");
            return question;
        }

        public override int read(XmlReader xml)
        {
            xml.ReadToFollowing("question");
            xml.MoveToAttribute("numberOfAnswer");
            return int.Parse(xml.Value);
        }
    }
    //3
    class XMLCategoryAndTitleHandler
    {
        public void write(XmlDocument doc, XmlElement ele, Question q)
        {
            XmlElement category = doc.CreateElement("category");
            category.InnerText = q.Category.Title;

            XmlElement title = doc.CreateElement("title");
            title.InnerText = q.Title;

            ele.AppendChild(category);
            ele.AppendChild(title);
        }

        public void read(XmlReader xml, Question q)
        {
            xml.ReadToFollowing("category");
            q.Category = new Category();
            q.Category.Title = xml.ReadElementContentAsString();

            xml.ReadToFollowing("title");
            q.Title = xml.ReadElementContentAsString();
        }
    }
    //4 
    interface XMLChosenCorrectHandler
    {
        void write(XmlDocument doc, XmlElement ele, Question q);

        void read(XmlReader xml, Question q);
    }
    class XMLCorrectIndexHandler : XMLChosenCorrectHandler
    {
        public void write(XmlDocument doc, XmlElement ele, Question q)
        {
            XmlElement correctAnswer = doc.CreateElement("correctIndex");
            correctAnswer.InnerText = q.CorrectIndex.ToString();

            ele.AppendChild(correctAnswer);
        }

        public void read(XmlReader xml, Question q)
        {
            xml.ReadToFollowing("correctIndex");
            q.CorrectIndex = xml.ReadElementContentAsInt();
        }
    }
    class XMLChosenIndexHandler : XMLChosenCorrectHandler
    {
        public void write(XmlDocument doc, XmlElement ele, Question q)
        {
            XmlElement chosenIndex = doc.CreateElement("chosenIndex");
            chosenIndex.InnerText = q.ChosenIndex.ToString();

            ele.AppendChild(chosenIndex);
        }

        public void read(XmlReader xml, Question q)
        {
            xml.ReadToFollowing("chosenIndex");
            q.ChosenIndex = xml.ReadElementContentAsInt();
        }
    }
    //5
    class XMLAnswerHandler
    {
        public void write(XmlDocument doc, XmlElement ele, Question q)
        {
            XmlElement answer = doc.CreateElement("answer");
            foreach (var i in q.LstAnswer.LstOption)
            {
                XmlElement option = doc.CreateElement("option");
                option.InnerText = i.OptionName;
                answer.AppendChild(option);
            }
            ele.AppendChild(answer);
        }

        public void read(XmlReader xml, Question q, int m)
        {
            xml.ReadToFollowing("answer");
            for (int j = 0; j < m; j++)
            {
                xml.ReadToFollowing("option");
                Option mco = new Option(xml.ReadElementContentAsString());
                q.addOption(mco);
            }
        }
    }
}
