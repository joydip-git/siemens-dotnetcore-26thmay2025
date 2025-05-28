using GenericAndGenericCollection;
using Entities;

//UseSet();
UseKeysAndValues();
static void UseCustomList()
{
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
}

static void UseSet()
{
    HashSet<int> set = new HashSet<int>();
    set.Add(10); //10.GetHashCode() => 1234
    set.Add(20); //20....() => 2134
    set.Add(10); //10....() => 1234 10.Equals(10)

    foreach (int item in set)
    {
        Console.WriteLine(item);
    }

    HashSet<Person> peopleSet = new HashSet<Person>();
    Person joydipPerson = new Person { Name = "joydip", Id = 1 };
    Person anotherPerson = new Person { Name = "joydip", Id = 1 };

    peopleSet.Add(joydipPerson);//jp.GHC() => 123
    peopleSet.Add(anotherPerson);//ap.GHC() => 123
    //ap.Equals(jp);

    foreach (Person item in peopleSet)
    {
        Console.WriteLine(item);
    }
}

static void UseKeysAndValues()
{
    //Dictionary<int, string> dictionary = new Dictionary<int, string>();
    SortedList<char,string> dictionary = new SortedList<char, string>();
    dictionary.Add('x', "siemens");
    dictionary.Add('a', "bangalore");
    //dictionary.Add(1, "Siemens Healthineers");
    dictionary['b'] = "Siemens Healthineers";

    foreach (KeyValuePair<char, string> item in dictionary)
    {
        Console.WriteLine(item.Key + ":" + item.Value);
    }
}

