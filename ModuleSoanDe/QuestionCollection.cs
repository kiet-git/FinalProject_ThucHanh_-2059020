using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public class QuestionCollection
    {
        private BindingList<Question> _listOfQuestions;

        public int Size
        {
            get
            {
                return _listOfQuestions.Count;
            }
        }

        public BindingList<Question> ListOfQuestions
        {
            get
            {
                return _listOfQuestions;
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

        private string _id;

        public string Id
        {
            get
            {
                return _id;
            }
        }

        private uint _month;

        public uint Month
        {
            get
            {
                return _month;
            }
        }

        public uint Year
        {
            get
            {
                return _year;
            }
        }

        private uint _year;

        public QuestionCollection(IXMLExecuter xmle)
        {
            _listOfQuestions = new BindingList<Question>();
            XMLExecuter = xmle;
        }

        public void transformToTest(uint month, uint year)
        {
            if (month < 1 || month > 12 || year < 1)
            {
                return;
            }
            _month = month;
            _year = year;
            _id = _month.ToString() + '-' + _year.ToString();
        }

        public void viewQuestion(int index)
        {
            if (index > -1 && index < _listOfQuestions.Count)
            {
                showFormCauHoi(_listOfQuestions[index], true);
            }
        }

        public Question getQuestion(int index)
        {
            return ListOfQuestions[index];
        }

        public void addQuestion()
        {
            Question q = new Question();
            _listOfQuestions.Add(q);
            showFormCauHoi(q, false);
        }

        public void addQuestion(Question q)
        {
            _listOfQuestions.Add(q);
        }

        public void updateQuestion(int index)
        {
            if (index > -1 && index < _listOfQuestions.Count)
            {
                showFormCauHoi(_listOfQuestions[index], false);
            }
        }

        public void deleteQuestion(int index)
        {
            if (index > -1 && index < _listOfQuestions.Count)
            {
                _listOfQuestions.RemoveAt(index);
                _listOfQuestions.ResetBindings();
            }
        }

        public void clearQuestion()
        {
            _listOfQuestions.Clear();
            _listOfQuestions.ResetBindings();
        }

        public void setDatasource(ListBox lb)
        {
            lb.DataSource = _listOfQuestions;
        }

        private void removeEnd()
        {
            _listOfQuestions.RemoveAt(_listOfQuestions.Count - 1);
        }

        private void showFormCauHoi(Question q, bool locked)
        {
            FormCauHoi fsch = new FormCauHoi(q);
            fsch.FormCauHoi_ExitWithoutSave += new FormCauHoi.FormCauHoi_ExitHandle(removeEnd);
            if (locked)
            {
                fsch.lockForm();
            }
            fsch.ShowDialog();
            _listOfQuestions.ResetBindings();
        }

        public void writeToXML(string filePath)
        {
            _XMLExecuter.writeQuestionCollection(this, filePath);
        }

        public void readXML(string filePath)
        {
            _XMLExecuter.readQuestionCollection(this, filePath);
            _listOfQuestions.ResetBindings();
        }

        private BindingList<Question> shallowClone()
        {
            BindingList<Question> resultList = new BindingList<Question>();
            foreach(var q in _listOfQuestions)
            {
                resultList.Add(q);
            }

            return resultList;
        }

        public QuestionCollection randomizeQuestion(int n)
        {
            BindingList<Question> clonedList = this.shallowClone();
            QuestionCollection randomizedQC = new QuestionCollection(new NormalXMLExecuter());

            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(clonedList.Count);
                randomizedQC.addQuestion(clonedList[index]);
                clonedList.RemoveAt(index);
            }

            return randomizedQC;
        }

        public bool checkEqual(Question q1)
        {
            foreach(var q in _listOfQuestions)
            {
                if(q.checkEqual(q1))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
