namespace OOPDemo
{
    sealed class Employee : Person
    {
        readonly int id;
        decimal salary;
        public const string COMPANY = "Siemens";
        //static string department = "DEPT";
        static string department;

        static Employee()
        {
            Console.WriteLine("static ctor...");
            department = "DEPT";
        }

        public Employee()
        {
            //department = string.Empty;
        }

        public Employee(string name, string emailId, string location, long mobileNo, decimal salary, int id) : base(name, emailId, location, mobileNo)
        {
            this.salary = salary;
            this.id = id;
        }

        //public int Id 
        //{ 
        //    get => id; 
        //}

        public int Id => id;

        public decimal Salary
        {
            get => salary;
            set => salary = value;
        }
        public static string Department
        {
            get => department;
            set => department = value;
        }
    }
}
