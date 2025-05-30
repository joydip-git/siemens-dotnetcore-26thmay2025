using System.Net.Http.Json;

namespace ThreadDemo;

class Program
{
    static void Main()
    {

        Console.WriteLine($"Main in Thread# " + Thread.CurrentThread.ManagedThreadId);
        //delegate void ThreadStart();
        ThreadStart runDel = new ThreadStart(Run);
        Thread runThrd = new Thread(runDel);
        runThrd.Start();
        runThrd.Join();
        //delegate void ParameterizedThreadStart(object? obj);
        ParameterizedThreadStart runWithDataDel = new ParameterizedThreadStart(RunWithData);
        Thread runWithDataThrd = new Thread(runWithDataDel);
        runWithDataThrd.Start(5);
        runWithDataThrd.Join();

        Thread.Sleep(1000);
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Main:{i} ");
        }
    }
    static void Run()
    {
        Console.WriteLine($"Run in Thread# " + Environment.CurrentManagedThreadId);
        Thread.Sleep(1000);
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Run:{i} ");
        }
    }
    static void RunWithData(object? arg)
    {
        HttpClient client = new HttpClient();        
        Console.WriteLine($"Run With Data in Thread# " + Environment.CurrentManagedThreadId);
        Thread.Sleep(5000);
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"RunWithData:{i} ");
        }
    }
}
