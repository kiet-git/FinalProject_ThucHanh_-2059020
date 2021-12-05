using System.Collections.Generic;

namespace ModuleSoanDe
{
    public class Category
    {
        private string _title;

        private List<string> _potentialValue = new List<string>()
        {
            "Phần mềm", "Phần cứng", "Mạng", "Bảo mật"
        };

        public Category()
        {
            _title = PotentialValue[0];
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != string.Empty && isPotentialValue(value))
                {
                    _title = value;
                }
            }
        }

        public List<string> PotentialValue
        {
            get {
                return _potentialValue;
            }
        }

        public bool isPotentialValue(string input)
        {
            foreach(var pv in PotentialValue)
            {
                if(input == pv)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
