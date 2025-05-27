namespace PolymorphismDemo
{
    class Person
    {
        private int id;
        private string name;

        public Person()
        {
            name = string.Empty;
        }

        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static bool operator >(Person a, Person b)
        {
            return a.id > b.id;
        }
        public static bool operator <(Person a, Person b)
        {
            return !(a.id > b.id);
        }

        public virtual string GetInformation() => $"Name={name}, Id={id}";
    }
}
