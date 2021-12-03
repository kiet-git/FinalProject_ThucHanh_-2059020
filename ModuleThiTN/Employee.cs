using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleThiTN
{
    public class Employee
    {
        private string _id;

        private string _name;

        private string _email;

        public Employee(string id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }
    }
}
