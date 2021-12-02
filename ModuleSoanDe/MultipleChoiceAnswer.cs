using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public class MultipleChoiceAnswers
    {

        private BindingList<MultipleChoiceOption> _listOfAnswers;

        public int Size
        {
            get
            {
                return _listOfAnswers.Count;
            }
        }

        public MultipleChoiceAnswers()
        {
            _listOfAnswers = new BindingList<MultipleChoiceOption>();
        }

        public BindingList<MultipleChoiceOption> ListOfAnswers
        {
            get
            {
                return _listOfAnswers;
            }
        }

        public string getAnswer(int index)
        {
            if (index >= 0)
                return _listOfAnswers[index].Answer;
            return null;
        }

        public bool addAnswer(MultipleChoiceOption mco)
        {
            if (mco.Answer != string.Empty)
            {
                _listOfAnswers.Add(mco);
                return true;
            }
            _listOfAnswers.ResetBindings();
            return false;
        }

        public bool updateAnswer(string ans, int index)
        {
            if (index >= 0 && index < _listOfAnswers.Count && !String.IsNullOrEmpty(ans))
            {
                _listOfAnswers[index].Answer = ans;
                _listOfAnswers.ResetBindings();
                return true;
            }
            return false;
        }

        public bool deleteAnswer(int index)
        {
            if (index >= 0 && index < _listOfAnswers.Count)
            {
                _listOfAnswers.RemoveAt(index);
                _listOfAnswers.ResetBindings();
                return true;
            }
            return false;
        }

        public void setDatasource(ListBox lb)
        {
            lb.DataSource = _listOfAnswers;
        }
    }
}
