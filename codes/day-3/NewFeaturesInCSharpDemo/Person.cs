namespace Entities;
class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void PrintMessage(string message)
    {
        Console.WriteLine(message + " " + Name);
    }
}
