using System;
using System.ComponentModel;

namespace ModuleSoanDe
{
    public class MultipleChoiceAnswers
    {

        private BindingList<MultipleChoiceOption> _listOfAnswers;

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
            set
            {
                if (value.Count >= 0)
                {
                    _listOfAnswers = value;
                }
            }
        }

        public MultipleChoiceOption getAnswer(int index)
        {
            if (index >= 0)
                return _listOfAnswers[index];
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

        public bool checkEmpty()
        {
            return _listOfAnswers.Count == 0;
        }

        public int getListCount()
        {
            return _listOfAnswers.Count;
        }
    }
}
