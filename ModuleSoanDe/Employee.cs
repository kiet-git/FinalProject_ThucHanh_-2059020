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
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
        }

        public Employee(string id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }
    }
}
