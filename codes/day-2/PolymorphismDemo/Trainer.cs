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

        public override string GetInformation() => $"{base.GetInformation()}, Subject:{subjectToTeach}";
    }
}
