using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{
    public class TestIdentification
    {
        public string Id
        {
            get
            {
                return _month.ToString() + '-' + _year.ToString();
            }
        }

        private uint _month;

        public uint Month
        {
            set
            {
                if (value >= 1 || value <= 12)
                {
                    _month = value;
                }
            }
            get
            {
                return _month;
            }
        }

        private uint _year;

        public uint Year
        {
            set
            {
                if (value >= 1)
                {
                    _year = value;
                }
            }
            get
            {
                return _year;
            }
        }

        public TestIdentification()
        {
            _month = 1;
            _year = 1;
        }
    }
}
