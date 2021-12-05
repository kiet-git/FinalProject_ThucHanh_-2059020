using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{
    public class Test
    {
        private TestIdentification _td;

        private QuestionCollection _qc;

        public int Size
        {
            get
            {
                return _qc.Size;
            }
        }

        public uint Month
        {
            get
            {
                return _td.Month;
            }
        }

        public uint Year
        {
            get
            {
                return _td.Year;
            }
        }

        public string Id
        {
            get
            {
                return _td.Id;
            }
        }

        public QuestionCollection Collection
        {
            get
            {
                return _qc;
            }
        }

        public Test()
        {
            _td = new TestIdentification();
            _qc = new QuestionCollection();
        }

        public Test(QuestionCollection qc, uint month, uint year)
        {
            _td = new TestIdentification();
            _td.Month = month;
            _td.Year = year;
            _qc = qc;
        }
        public void writeXML()
        {
            string fileName = _td.Id + ".xml";
            _qc.XMLExecuter = new TestXMLExecuter(_td);
            _qc.writeXML(fileName);
        }

        public void readXML(string fileName)
        {
            _qc.XMLExecuter = new TestXMLExecuter(_td);
            _qc.readXML(fileName);
        }

        public void readEmXML(Employee e, string fileName)
        {
            _qc.XMLExecuter = new EmployeeTestXMLExecuter(_td, e);
            _qc.readXML(fileName);
        }

        public void writeEmXML(Employee e, string fileName)
        {
            _qc.XMLExecuter = new EmployeeTestXMLExecuter(_td, e);
            _qc.writeXML(fileName);
        }
        public void readCorrectXML(string fileName)
        {
            _qc.XMLExecuter = new CorrectAnswerXMLExecuter(_td);
            _qc.readXML(fileName);
        }
    }

}
