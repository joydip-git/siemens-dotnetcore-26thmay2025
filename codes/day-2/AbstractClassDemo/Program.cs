namespace AbstractClassDemo
{
    internal class Program
    {
        static void Main()
        {
            int choice = 2;
            DataAccess? dataAccess = Create(choice);
            string? data = dataAccess?.GetData();
            Console.WriteLine(data);
        }

        private static DataAccess? Create(int choice = 1)
        {
            /*
            DataAccess? dataAccess;
            switch (choice)
            {
                case 1:
                    dataAccess = new DbDataAccess();
                    break;

                    case 2:
                        dataAccess = new TextFileDataAccess();
                    break;

                default:
                    dataAccess = null;
                    break;
            }
            return dataAccess;
            */

            //switch expression

            //DataAccess? dataAccess = choice switch
            //{
            //    1 => dataAccess= new DbDataAccess(),
            //    2 => dataAccess= new TextFileDataAccess(),
            //    _ => null
            //};
            //return dataAccess;


            return choice switch
            {
                1 => new DbDataAccess(),
                2 => new TextFileDataAccess(),
                _ => null
            };
        }
    }
}
