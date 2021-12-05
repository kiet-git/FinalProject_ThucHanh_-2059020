using System;

namespace ModuleSoanDe
{
    public class Option
    {
        private string _option;
        public string OptionName
        {
            get
            {
                return _option;
            }
            set
            {
                if (value != string.Empty)
                {
                    _option = value;
                }
            }
        }

        public Option(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _option = input;
            }
        }

        public bool checkEqual(Option o)
        {
            return o.OptionName == this.OptionName;
        }

        public override string ToString()
        {
            return _option;
        }
    }
}
