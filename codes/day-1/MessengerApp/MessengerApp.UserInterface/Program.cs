using MessengerApp.Logic;

namespace MessengerApp.UserInterface
{
    internal class Program
    {
        static void Main()
        {
            //Messenger messenger = new Messenger();
            Messenger messenger = new();
            string message = messenger.GetMessage("joydip");
            Console.WriteLine($"Message: {message}");
        }
    }
}
