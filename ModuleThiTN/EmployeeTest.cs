using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleSoanDe;

namespace ModuleThiTN
{
    public class EmployeeTest
    {
        private Employee _employee;

        private Test _test;
      

        public Test CurrentTest
        {
            get
            {
                return _test;
            }
        }

        public Employee CurrentEm
        {
            get
            {
                return _employee;
            }
        }

        public EmployeeTest(Employee e, Test t)
        {
            _employee = e;
            _test = t;
        }

        public void writeXML(string fileName)
        {
            _test.writeEmXML(_employee, fileName);
        }
    }
}
