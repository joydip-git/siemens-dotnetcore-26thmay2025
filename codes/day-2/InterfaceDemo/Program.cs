namespace InterfaceDemo
{
    interface IOpertions
    {
        void Add(int x, int y);
    }
    interface IResult
    {
        int Result { get; }
    }
    class Operations : IOpertions, IResult
    {
        int result;

        public int Result => result;

        public void Add(int x, int y)
        {
            result = x + y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //implicit invocation of interface members
            Operations ops = new();            
            ops.Add(1, 2);
            Console.WriteLine(ops.Result);

            //expliclt invocation of interface members
            IOpertions opsContract = ops;
            opsContract.Add(1, 2);

            IResult result = ops;
            Console.WriteLine(result.Result);
        }
    }
}
