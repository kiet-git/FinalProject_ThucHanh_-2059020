using System;
using System.Windows.Forms;

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
                if(value >= 0 && value < LstAnswer.Size)
                {
                    _correctIndex = value; 
                } 
            }
        }

        private int _chosenIndex;

        public int ChosenIndex
        {
            get
            {
                return _chosenIndex;
            }
            set
            {
                if (value >= 0 && value < LstAnswer.Size)
                {
                    _chosenIndex = value;
                }
            }
        }

        private MultipleChoiceAnswer _lstAnswer;

        public MultipleChoiceAnswer LstAnswer
        {
            get
            {
                return _lstAnswer;
            }
        }

        public int LstAnswerSize
        {
            get
            {
                return _lstAnswer.Size;
            }
        }

        public Question()
        {
            _category = new Category();
            _title = "";
            _correctIndex = -1;
            _chosenIndex = -1;
            _lstAnswer = new MultipleChoiceAnswer();
        }

        public string getCorrectAnswer()
        {
            if(CorrectIndex >= 0)  
                return _lstAnswer.getOptionAsString(CorrectIndex);
            return "";
        }

        public bool checkEqual(Question q)
        {
            if(q.Category.Title == this.Category.Title 
               && q.Title == this.Title
               && q.CorrectIndex == this.CorrectIndex)
            {
                for(int i = 0; i < _lstAnswer.Size; i++)
                {
                    if(!this.LstAnswer.getOption(i).checkEqual(q.LstAnswer.getOption(i)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool isChosen()
        {
            return _chosenIndex > -1;
        }

        public void setAnswerDataSource(ListBox lb)
        {
            _lstAnswer.setDatasource(lb);
        }

        public string getOptionAsString(int index)
        {
            return _lstAnswer.getOptionAsString(index);
        }

        public void addOption(Option o)
        {
            _lstAnswer.addOption(o);
        }

        public void updateOption(string ans, int index)
        {
            _lstAnswer.updateOption(ans, index);
        }

        public void deleteOption(int index)
        {
            _lstAnswer.deleteOption(index);
        }

        public override string ToString()
        {
            return _title;
        }
    }
}
