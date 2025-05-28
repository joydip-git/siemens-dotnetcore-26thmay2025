using GenericAndGenericCollection;

ItemList<int> numbers = new ItemList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(50);
numbers.Add(40);
Console.WriteLine(numbers.Capacity);
Console.WriteLine(numbers.Count);
//numbers.Remove(20);
//public static IEnumerable<T> Where(this IEnumerable<T> e,....);
//for (int i = 0; i < numbers.Count; i++)
//{
//    Console.WriteLine(numbers[i]);
//}
//foreach (int item in numbers)
//{
//    Console.WriteLine(item);
//}

IEnumerator<int> enumerator = numbers.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}

