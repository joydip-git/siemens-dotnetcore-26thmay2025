namespace AbstractClassDemo
{
    internal class DbDataAccess : DataAccess
    {
        public DbDataAccess()
        {

        }
        public DbDataAccess(string path) : base(path)
        {

        }
        public override string GetData()
        {
            return "database data";
        }
    }
}
