namespace PolymorphismDemo
{
    internal class Trainer : Person
    {
        string subjectToTeach;

        public Trainer()
        {

        }
        public Trainer(int id, string name, string subject) : base(id, name)
        {
            subjectToTeach = subject;
        }

        public string SubjectToTeach
        {
            get => subjectToTeach;
            set => subjectToTeach = value;
        }

        public string PrintInformation() => $"{base.GetInformation()}, Subject:{subjectToTeach}";
    }
}
