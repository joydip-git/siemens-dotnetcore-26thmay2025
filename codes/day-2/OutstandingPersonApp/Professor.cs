namespace OutstandingPersonApp
{
    public class Professor : Person
    {
        public int BooksPublished { get; set; }

        public Professor()
        {

        }
        public Professor(string name, int booksPublished) : base(name)
        {
            BooksPublished = booksPublished;
        }

        public override bool IsOutstanding() => BooksPublished >= 5;
    }
}
