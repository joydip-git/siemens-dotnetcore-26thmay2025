namespace AbstractClassDemo
{
    internal class TextFileDataAccess : DataAccess
    {
        public TextFileDataAccess()
        {

        }
        public TextFileDataAccess(string path) : base(path)
        {

        }
        public override string GetData()
        {
            return "file data";
        }
    }
}
