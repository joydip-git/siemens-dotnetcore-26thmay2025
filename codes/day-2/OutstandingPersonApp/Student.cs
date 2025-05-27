namespace OutstandingPersonApp
{
    public class Student : Person
    {
        public double Marks { get; set; }
        public Student()
        {

        }
        public Student(string name, double marks) : base(name)
        {
            Marks = marks;
        }

        public override bool IsOutstanding() => Marks >= 85;
    }
}
