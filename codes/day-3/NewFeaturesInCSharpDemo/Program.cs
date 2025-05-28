using Entities;
using CalculationLibrary;
using ExtensionLibrary;

Calculation calc = new Calculation();
Console.WriteLine(calc.Add(5, 10));
Console.WriteLine(calc.Subtract(10, 5));

Person person = new Person("anil");
string name = "anil";
System.Console.WriteLine(name.SayHello("joydip"));
PrintMessage("Hello, World!");
PrintMessageStatic("Hello, World!");
//local function
void PrintMessage(string message)
{
    Console.WriteLine(message + " " + name);
}
static void PrintMessageStatic(string message)
{
    Console.WriteLine(message);
}