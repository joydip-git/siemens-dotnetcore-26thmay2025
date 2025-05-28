//1. create a list to store integers
//2. create static local function (Filter) which can be called to get the filtered numbers from a list
//3. call the method, pass the list created in the 1st step
//4. the method MUST return another list with just the filtered numbers
//5. print the filtered numbers
//filter the even numbers from the list

List<int> numbers = [1, 3, 5, 2, 6, 4, 8, 9, 7, 0];
List<int> result = Filter(numbers);
foreach (int number in result)
{
    Console.WriteLine(number);
}

static List<int> Filter(List<int> input)
{
    List<int> output = [];
    foreach (int item in input)
    {
        if (item % 2 == 0)
            output.Add(item);
    }
    return output;
}

static bool IsEven(int value) => value % 2 == 0;
static bool IsOdd(int value) => value % 2 != 0;
