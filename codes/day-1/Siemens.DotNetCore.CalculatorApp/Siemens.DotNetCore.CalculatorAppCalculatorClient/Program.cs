using Siemens.DotNetCore.CalculatorApp.CalculatorLibrary;

namespace Siemens.DotNetCore.CalculatorAppCalculatorClient
{
    internal class Program
    {
        static void Main()
        {
            char toContinue = 'n';
            do
            {
                PrintMenu();
                int choice = GetChoice();

                int firstValue = GetValue();
                int secondValue = GetValue();

                string method;
                Nullable<int> result = Calculate(choice, firstValue, secondValue, out method);
                if (!result.HasValue)
                    Console.WriteLine("enter a proper choice");
                else
                {

                    PrintResultWithMethodName(result.Value, method);
                }
                DecideToContinue(ref toContinue);
            } while (toContinue != 'n');
        }
        static void PrintMenu() => Console.WriteLine("1. Add\n2. Subtract\n3. Multiply\n4. Divide");

        static int GetChoice()
        {
            Console.Write("\nEnter Choice[1/2/3/4]: ");
            //string strChoice = Console.ReadLine(); //1 -> "1"
            //return int.Parse(strChoice);
            return int.Parse(Console.ReadLine());
        }
        static int GetValue()
        {
            Console.Write("\nEnter Value: ");
            return int.Parse(Console.ReadLine());
        }
        static int? Calculate(int choice, int first, int second, out string methodName)
        {
            int? result;
            Calculator calculator = new();
            switch (choice)
            {
                case 1:
                    //methodName = "Add";
                    methodName = nameof(calculator.Add);
                    result = calculator.Add(first, second);
                    break;

                case 2:
                    methodName = nameof(calculator.Subtract);
                    result = calculator.Subtract(first, second);
                    break;

                case 3:
                    methodName = nameof(Calculator.Multiply);
                    result = calculator.Multiply(first, second);
                    break;

                case 4:
                    methodName =nameof(Calculator.Divide);
                    result = calculator.Divide(first, second);
                    break;

                default:
                    methodName = String.Empty;
                    result = null;
                    break;
            }
            return result;
        }
        static void PrintResultWithMethodName(int result, string methodName) => Console.WriteLine($"Result of {methodName} is {result}");

        static void DecideToContinue(ref char decision)
        {
            Console.Write("\nContinue[y/Y/n/N]: ");
            decision = char.Parse(Console.ReadLine());
            if (char.IsUpper(decision))
                decision = char.ToLower(decision);
        }
    }
}
