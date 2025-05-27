namespace AbstractClassDemo
{
    internal abstract class DataAccess : IDataAccess
    {
        public string Path { get; set; } = string.Empty;

        public DataAccess()
        {

        }
        public DataAccess(string path)
        {
            Path = path;
        }
        //string GetData();
        public abstract string GetData();
    }
}
