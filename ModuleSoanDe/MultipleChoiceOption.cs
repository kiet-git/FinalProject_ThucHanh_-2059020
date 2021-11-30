using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{
    public class MultipleChoiceOption
    {
        private string _answer;
        public string Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                if (value != string.Empty)
                {
                    _answer = value;
                }
            }
        }

        public MultipleChoiceOption(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                _answer = input;
            }
        }

        public override string ToString()
        {
            return _answer;
        }
    }
}
