using System.Reflection;

List<int> numbers = [1, 4, 2, 6, 3, 8, 5, 9, 7, 0];

Func<int, bool> isEven = x => x % 2 == 0;

//Language Integrated Query (LINQ):
//1. OOP
//2. generic
//3. collection and interfaces
//4. delegate
//5. new features

//1. Method syntax
numbers
    .Where(isEven)
    .OrderByDescending(x => x)
    .Take(3)
    .ToList()
    .ForEach(x => Console.WriteLine(x));

//2. query syntax
var query = from x in numbers
            where x % 2 == 0
            orderby x descending
            select x;

query.Take(3).ToList().ForEach(x => Console.WriteLine(x));

//implcitly typed local variable
var a = 10;

var v = Get();
static string? Get() => $"hello";

//static class Eneumrable
//{
//public static IEnumerable<T> Where<T>(this IEnumerable<T> e, Func<T,Result>(T value)){}
//}


//public delegate void EventHandler(object> sender, EventArgs e);

Button button1 = new Button();
button1.Click += new EventHandler(ButtonClicked);
button1.OnClick();

static void ButtonClicked(object? sender, EventArgs e)
{
    Console.WriteLine(sender?.GetType().Name + " was clicked");
}
class Button
{
    public string Text { get; set; } = string.Empty;
    public event EventHandler? Click;

    public void OnClick()
    {
        if (Click != null)
            this.Click(this, new EventArgs());
    }
}
