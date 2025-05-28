//1. create a list to store integers
//2. create static local function (Filter) which can be called to get the filtered numbers from a list
//3. call the method, pass the list created in the 1st step
//4. the method MUST return another list with just the filtered numbers
//5. print the filtered numbers
//filter the even numbers from the list

List<int> numbers = [1, 3, 5, 2, 6, 4, 8, 9, 7, 0];
List<string> names = ["anil", "sunil", "joydip"];

//Logic evenDel = IsEven;
//Logic<int> evenDel = IsEven;
//Logic<int> oddDel = new Logic<int>(IsOdd);
//Logic<int> isGreater = x => x > 5;
Logic<string> containsN = name => name.ToLower().Contains('n');

Predicate<int> evenDel = IsEven;
Predicate<int> oddDel = new Predicate<int>(IsOdd);

//Func<string, bool> containsN = name => name.Contains('n');
Func<int, int, int> compare = (x, y) => x - y;
//List<int> result = Filter(numbers, isGreater);
List<string> result = Filter(names, containsN);
//foreach (int number in result)
foreach (string item in result)
{
    Console.WriteLine(item);
}

//static List<int> Filter(List<int> input, Logic logic)
static List<T> Filter<T>(List<T> input, Logic<T> logic)
{
    List<T> output = [];
    foreach (T item in input)
    {
        bool isTrue = logic(item);
        if (isTrue)
            output.Add(item);
    }
    return output;
}

static bool IsEven(int value) => value % 2 == 0;
static bool IsOdd(int value) => value % 2 != 0;

//delegate bool Logic(int x);
delegate bool Logic<in T>(T value);
delegate TResult Logic<in T, out TResult>(T value);

//delegate bool Predicate<in T>(T value);

//delegate TResult Func<out TResult>();
//delegate TResult Func<in T, out TResult>(T value);
//delegate TResult Func<in T1,in T2, out TResult>(T1 value1, T2 value2);
//.....
//delegate TResult Func<in T1,in T2,...,in T16, out TResult>(T1 value1, T2 value2,....,T16 value16);

//delegate void Action<in T> (T value);