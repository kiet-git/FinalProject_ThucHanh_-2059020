using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{
    public class Test
    {
        private string _id;

        private uint _month;

        private uint _year;

        private QuestionCollection _questionCollection;

        private IXMLExecuter _XmlExecuter;
    

        public Test(uint month, uint year, QuestionCollection qc, IXMLExecuter ixml)
        {
            if(month < 1 || month > 12 || year < 1 || qc is null)
            {
                return;
            }
            _month = month;
            _year = year;
            _id = _month.ToString() + '-' + _year.ToString();
            _questionCollection = qc;
            _XmlExecuter = ixml;
        }

        public void writeXML()
        {

        }

        public void readXML()
        {

        }
    }
}
