using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public abstract class IQCollection
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
            set
            {
                _lstQuestions = value;
            }
            get
            {
                return _lstQuestions;
            }
        }

        protected IXMLExecuter _XMLExecuter;

        public IQCollection()
        {
            _lstQuestions = new BindingList<Question>();
        }

        public virtual void writeXML(string fileName)
        {
            _XMLExecuter.write(fileName);
        }

        public virtual void readXML(string fileName)
        {
            _XMLExecuter.read(fileName);
            this.resetBinding();
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

        public void deleteQuestion(int index)
        {
            if (index > -1 && index < Size)
            {
                _lstQuestions.RemoveAt(index);
                this.resetBinding();
            }
        }
    }

    public class NormalQCollection : IQCollection
    {
        private FormCauHoiCreator _fc;

        public NormalQCollection() : base()
        {
            _fc = new FormCauHoiCreator(this, false);
            _XMLExecuter = new NormalXMLExecuter(this);
        }

        public void removeEnd()
        {
            _lstQuestions.RemoveAt(Size - 1);
            this.resetBinding();
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

        public BindingList<Question> randomizeQuestionToTest(int n)
        {
            BindingList<Question> clonedList = this.shallowClone();
            BindingList<Question> randomizedList = new BindingList<Question>();

            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(clonedList.Count);
                randomizedList.Add(clonedList[index]);
                clonedList.RemoveAt(index);
            }

            return randomizedList;
        }
    }

    public class TestQCollection : IQCollection
    {
        private TestIdentification _td;

        public uint Month
        {
            set
            {
                _td.Month = value;
            }
            get
            {
                return _td.Month;
            }
        }

        public uint Year
        {
            set
            {
                _td.Year = value;
            }
            get
            {
                return _td.Year;
            }
        }

        public string Id
        {
            get
            {
                return _td.Id;
            }
        }

        public IXMLExecuter XMLExecuter
        {
            set
            {
                _XMLExecuter = value;
            }
        }

        public TestQCollection() : base()
        {
            _td = new TestIdentification();
            _XMLExecuter = new TestXMLExecuter(this);
        }

        public TestQCollection(BindingList<Question> qc, uint month, uint year)
        {
            _td = new TestIdentification();
            _td.Month = month;
            _td.Year = year;
            _lstQuestions = qc;
        }

        public override void writeXML(string fileName)
        {
            fileName = _td.Id + ".xml";
            base.writeXML(fileName);
        }

        public virtual void writeXMLNormally(string fileName)
        {
            base.writeXML(fileName);
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

        public void clearQuestion()
        {
            _lstQuestions.Clear();
            this.resetBinding();
        }

        public int markTest(IQCollection qc)
        {
            int mark = 0;
            for (int i = 0; i < Size; i++)
            {
                Question a = LstQuestion[i];
                Question b = qc.LstQuestion[i];
                if (a.Title == b.Title
                    && a.Category.Title == b.Category.Title
                    && a.isCorrect(b.ChosenIndex))
                {
                    mark++;
                }
            }
            return mark;
        }
    }

    public class EmTestQCollection : TestQCollection
    {
        private Employee _employee;

        private int _mark;

        public string EmName
        {
            set
            {
                _employee.Name = value;
            }
            get
            {
                return _employee.Name;
            }
        }

        public string EmId
        {
            set
            {
                _employee.Id = value;
            }
            get
            {
                return _employee.Id;
            }
        }

        public string EmEmail
        {
            set
            {
                _employee.Email = value;
            }
            get
            {
                return _employee.Email;
            }
        }

        public int Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
            }
        }

        public EmTestQCollection() : base()
        {
            _employee = new Employee();
            _XMLExecuter = new EmployeeTestXMLExecuter(this);
        }

        public override void writeXML(string fileName)
        {
            base.writeXMLNormally(fileName);
        }
    }
}
