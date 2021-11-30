using System;

namespace ModuleSoanDe
{
    public class Question
    {
        private Category _category;

        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                if(value.Title != String.Empty)
                {
                    _category.Title = value.Title;
                }
            }
        }

        private string _title;

        public string Title {
            get
            {
                return _title;
            }
            set
            {
                if (value != string.Empty)
                {
                    _title = value;
                }
            }
        }

        private int correctIndex;

        private MultipleChoiceAnswers _listOfAnswers;

        public MultipleChoiceAnswers ListOfAnswers
        {
            get
            {
                return _listOfAnswers;
            }
            set
            {
                _listOfAnswers = value;
            }
        }

        public Question()
        {
            _category = new Category()
            {
                Title = ""
            };
            _title = "";
            _listOfAnswers = new MultipleChoiceAnswers();
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
