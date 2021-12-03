using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleSoanDe;

namespace ModuleThi
{
    public class Test
    {
        private Employee _employee;

        private string _testId;

        List<int> _chosenIndex;

        public Test(Employee e, string testId)
        {
            _employee = e;
            _chosenIndex = new List<int>();
            _testId = testId;
        }
    }
}
