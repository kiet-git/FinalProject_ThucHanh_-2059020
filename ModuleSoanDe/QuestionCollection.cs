using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public class QuestionCollection
    {
        protected BindingList<Question> _lstQuestions;

        public int Size
        {
            get
            {
                return _lstQuestions.Count;
            }
        }

        public BindingList<Question> LstQuestion
        {
            get
            {
                return _lstQuestions;
            }
        }

        private IXMLExecuter _XMLExecuter;

        public IXMLExecuter XMLExecuter
        {
            set
            {
                _XMLExecuter = value;
            }
        }

        private FormCauHoiCreator _fc;

        public QuestionCollection()
        {
            _lstQuestions = new BindingList<Question>();
            _fc = new FormCauHoiCreator(this, false);
        }

        public void setDatasource(ListBox lb)
        {
            lb.DataSource = _lstQuestions;
        }

        public void resetBinding()
        {
            _lstQuestions.ResetBindings();
        }

        public Question getQuestion(int index)
        {
            return _lstQuestions[index];
        }

        public void addQuestion(Question q)
        {
            _lstQuestions.Add(q);
            _lstQuestions.ResetBindings();
        }

        public void clearQuestion()
        {
            _lstQuestions.Clear();
            this.resetBinding();
        }

        public void removeEnd()
        {
            _lstQuestions.RemoveAt(Size - 1);
            this.resetBinding();
        }

        public void deleteQuestion(int index)
        {
            if (index > -1 && index < Size)
            {
                _lstQuestions.RemoveAt(index);
                this.resetBinding();
            }
        }

        public void writeXML(string fileName)
        {
            _XMLExecuter.writeQuestionCollection(this, fileName);
        }

        public void readXML(string fileName)
        {
            _XMLExecuter.readQuestionCollection(this, fileName);
            this.resetBinding();
        }

        public bool checkEqual(Question q1)
        {
            foreach (var q in _lstQuestions)
            {
                if (q.checkEqual(q1))
                {
                    return true;
                }
            }
            return false;
        }

        public void viewQuestionInFormCauHoi(int index)
        {
            if (index > -1 && index < _lstQuestions.Count)
            {
                _fc.IsLocked = true;
                _fc.showFormCauHoi(_lstQuestions[index]);
            }
        }

        public void addQuestionAndShowFormCauHoi()
        {
            Question q = new Question();
            _lstQuestions.Add(q);
            _fc.showFormCauHoi(q);
        }

        public void updateQuestionAndShowFormCauHoi(int index)
        {
            if (index > -1 && index < Size)
            {
                _fc.showFormCauHoi(_lstQuestions[index]);
            }
        }

        private BindingList<Question> shallowClone()
        {
            BindingList<Question> resultList = new BindingList<Question>();
            foreach (var q in _lstQuestions)
            {
                resultList.Add(q);
            }

            return resultList;
        }

        public QuestionCollection randomizeQuestionToTest(int n)
        {
            BindingList<Question> clonedList = this.shallowClone();
            QuestionCollection randomizedQC = new QuestionCollection();

            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(clonedList.Count);
                randomizedQC.addQuestion(clonedList[index]);
                clonedList.RemoveAt(index);
            }

            return randomizedQC;
        }
    }
}
