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
                if(value >= 0 && value < AnswerCollection.Size)
                {
                    _correctIndex = value; 
                } 
            }
        }

        private MultipleChoiceAnswers _answerCollection;

        public MultipleChoiceAnswers AnswerCollection
        {
            get
            {
                return _answerCollection;
            }
            set
            {
                _answerCollection = value;
            }
        }

        public Question()
        {
            _category = new Category();
            _title = "";
            _correctIndex = -1;
            AnswerCollection = new MultipleChoiceAnswers();
        }

        public override string ToString()
        {
            return Title;
        }

        public string getCorrectAnswer()
        {
            if(this.CorrectIndex >= 0)  
                return this.AnswerCollection.getAnswer(this.CorrectIndex);
            return "";
        }

        public bool checkEqual(Question q)
        {
            if(q.Category.Title == this.Category.Title 
               && q.Title == this.Title
               && q.CorrectIndex == this.CorrectIndex)
            {
                for(int i = 0; i < AnswerCollection.Size; i++)
                {
                    if(AnswerCollection.ListOfAnswers[i].Answer != q.AnswerCollection.ListOfAnswers[i].Answer)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
