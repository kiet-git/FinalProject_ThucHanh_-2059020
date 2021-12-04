using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleSoanDe;

namespace ModuleThiTN
{
    public class Test
    {
        private Employee _employee;

        private string _testId;

        private QuestionCollection _questionCollection;

        //private IXMLExecuter _XMLExecuter;

        public Test(Employee e, string testId, QuestionCollection qc)
        {
            _employee = e;
            _testId = testId;
            _questionCollection = qc;
            //_XMLExecuter = new EmployeeTestXMLExecuter();
        }
    }
}
