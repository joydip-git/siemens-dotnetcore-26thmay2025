namespace HelloWorld
{
    internal class Program
    {
        //static void Main(string[] args)
        //static void Main()
        //static int Main(string[] args)
        //static int Main()
        static void Main()
        {
            //int x = 10;
            //Int32 y = 20;
            Console.WriteLine("Hello, World!");
            SayHi();
            SayHi();
            Console.WriteLine("press any key to close the app...");
            Console.ReadKey();
        }
        static void SayHi()
        {
            Console.WriteLine("Hi...");
        }
    }
}
