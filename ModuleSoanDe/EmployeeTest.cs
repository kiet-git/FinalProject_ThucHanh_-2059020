using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleSoanDe;

namespace ModuleSoanDe
{
    public class EmployeeTest
    {
        private Employee _employee;

        private Test _test;

        private int _mark;

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

        public int Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
            }
        }

        public EmployeeTest()
        {
            _employee = new Employee();
            _test = new Test();
            _mark = 0;
        }

        public EmployeeTest(Employee e, Test t)
        {
            _employee = e;
            _test = t;
            _mark = 0;
        }

        public void writeXML(string fileName)
        {
            _test.writeEmXML(_employee, fileName);
        }

        public void readXML(string fileName)
        {
            _test.readEmXML(_employee, fileName);
        }
    }
}
