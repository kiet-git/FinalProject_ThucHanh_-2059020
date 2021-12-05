namespace ModuleSoanDe
{
    public class Employee
    {
        private string _id;

        private string _name;

        private string _email;

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public Employee()
        {
            _id = "";
            _name = "";
            _email = "";
        }
        public Employee(string id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }
    }
}
