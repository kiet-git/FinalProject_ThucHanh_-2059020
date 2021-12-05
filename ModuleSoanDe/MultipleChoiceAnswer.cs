using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public class MultipleChoiceAnswer
    {
        private BindingList<Option> _lstOption;

        public int Size
        {
            get
            {
                return _lstOption.Count;
            }
        }

        public MultipleChoiceAnswer()
        {
            _lstOption = new BindingList<Option>();
        }

        public BindingList<Option> LstOption
        {
            get
            {
                return _lstOption;
            }
        }

        public string getOptionAsString(int index)
        {
            if (index >= 0)
                return _lstOption[index].OptionName;
            return null;
        }

        public Option getOption(int index)
        {
            if (index >= 0)
                return _lstOption[index];
            return null;
        }

        public bool addOption(Option mco)
        {
            if (mco.OptionName != string.Empty)
            {
                _lstOption.Add(mco);
                return true;
            }
            _lstOption.ResetBindings();
            return false;
        }

        public bool updateOption(string ans, int index)
        {
            if (index >= 0 && index < this.Size && !String.IsNullOrEmpty(ans))
            {
                _lstOption[index].OptionName = ans;
                _lstOption.ResetBindings();
                return true;
            }
            return false;
        }

        public bool deleteOption(int index)
        {
            if (index >= 0 && index < this.Size)
            {
                _lstOption.RemoveAt(index);
                _lstOption.ResetBindings();
                return true;
            }
            return false;
        }

        public void setDatasource(ListBox lb)
        {
            lb.DataSource = _lstOption;
        }
    }
}
