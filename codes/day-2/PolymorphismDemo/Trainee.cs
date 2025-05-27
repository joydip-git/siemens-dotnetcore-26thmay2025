namespace PolymorphismDemo
{
    class Trainee : Person
    {
        string subjectToLearn;

        public Trainee()
        {

        }
        public Trainee(int id, string name, string subject) : base(id, name)
        {
            subjectToLearn = subject;
        }
        public string SubjectToLearn 
        {
            get => subjectToLearn; 
            set => subjectToLearn = value;
        }

        public override string GetInformation() => $"{base.GetInformation()}, Subject to Learn:{subjectToLearn}";
    }
}
