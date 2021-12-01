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

        private int _correctIndex;

        public int CorrectIndex
        {
            get
            {
                return _correctIndex;
            }
            set
            {
                if(value >= 0 && value < _answers.getListCount())
                {
                    _correctIndex = value; 
                } 
            }
        }

        private MultipleChoiceAnswers _answers;

        public MultipleChoiceAnswers Answers
        {
            get
            {
                return _answers;
            }
            set
            {
                _answers = value;
            }
        }

        public Question()
        {
            _category = new Category()
            {
                Title = ""
            };
            _title = "";
            _correctIndex = -1;
            _answers = new MultipleChoiceAnswers();
        }

        public override string ToString()
        {
            return Title;
        }

        public string getCorrectAnswer()
        {
            if(this.CorrectIndex >= 0)  
                return this.Answers.getAnswer(this.CorrectIndex).Answer;
            return "";
        }
    }
}
