namespace OutstandingPersonApp
{
    public abstract class Person
    {
        public string Name { get; set; } = string.Empty;

        public Person()
        {

        }
        public Person(string name) => Name = name;

        public abstract bool IsOutstanding();
    }
}
