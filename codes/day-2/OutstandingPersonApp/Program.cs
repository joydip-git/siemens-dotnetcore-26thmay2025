namespace OutstandingPersonApp
{
    internal class Program
    {
        static void Main()
        {
            Person[] people =
            [
                new Student { Name = "anil", Marks = 78 },
                new Professor { Name = "sunil", BooksPublished = 8 },
                new Student { Name = "vinod", Marks = 87 },
                new Professor { Name = "murali", BooksPublished = 4 },
            ];
            foreach (Person person in people)
            {
                if (person.IsOutstanding())
                {
                    Type typeOfPerson = person.GetType();
                    Console.WriteLine($"Name={person.Name} is outstanding {typeOfPerson.Name}");
                }
            }
        }
    }
}
