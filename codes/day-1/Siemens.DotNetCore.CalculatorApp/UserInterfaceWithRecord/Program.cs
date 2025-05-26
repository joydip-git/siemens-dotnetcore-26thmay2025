using Siemens.DotNetCore.CalculatorApp.CalculatorLibrary;

namespace UserInterfaceWithRecord
{
    internal class Program
    {
        static void Main()
        {
            //string? is not requal to Nullable<string>
            //Nullable<T> is used or value type variable
            string? str = null;
            //Console.WriteLine(str != null ? str : "NA");
            Console.WriteLine(str ?? "NA");
            Console.WriteLine(str?.ToUpper());
            char toContinue = 'n';
            do
            {
                PrintMenu();
                int choice = GetChoice();

                int firstValue = GetValue();
                int secondValue = GetValue();

                //(int?,string) returnValue = Calculate(choice, firstValue, secondValue);
                CalculationResult returnValue = Calculate(choice, firstValue, secondValue);
                //if (returnValue.Item1.HasValue)
                if (returnValue.Result.HasValue)
                    Console.WriteLine("enter a proper choice");
                else
                {
                    //PrintResultWithMethodName(returnValue.Item1.Value, returnValue.Item2);
                    if (returnValue.Result.HasValue)
                    {
                        PrintResultWithMethodName(returnValue.Result.Value, returnValue.MethodName);
                    }
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
            return int.Parse(Console.ReadLine() ?? "1");
        }
        static int GetValue()
        {
            Console.Write("\nEnter Value: ");
            return int.Parse(Console.ReadLine() ?? "0");
        }
        //static (int?,string) Calculate(int choice, int first, int second)

        static CalculationResult Calculate(int choice, int first, int second)
        {
            int? result;
            Calculator calculator = new();
            string methodName;

            switch (choice)
            {
                case 1:
                    methodName = nameof(calculator.Add);
                    result = calculator.Add(first, second);
                    break;

                case 2:
                    methodName = nameof(calculator.Subtract);
                    result = calculator.Subtract(first, second);
                    break;

                case 3:
                    methodName = nameof(calculator.Multiply);
                    result = calculator.Multiply(first, second);
                    break;

                case 4:
                    methodName = nameof(calculator.Divide);
                    result = calculator.Divide(first, second);
                    break;

                default:
                    methodName = string.Empty;
                    result = null;
                    break;
            }
            //return (result,methodName);
            return new CalculationResult(Result: result, MethodName: methodName);
        }
        static void PrintResultWithMethodName(int result, string methodName) => Console.WriteLine($"Result of {methodName} is {result}");

        static void DecideToContinue(ref char decision)
        {
            Console.Write("\nContinue[y/Y/n/N]: ");
            decision = char.Parse(Console.ReadLine() ?? "n");
            if (char.IsUpper(decision))
                decision = char.ToLower(decision);
        }
    }

    record CalculationResult(int? Result, string MethodName);
    //class CalculationResult
    //{
    //    private int? result;
    //    private string methodName;

    //    public int? Result
    //    {
    //        get { return result; }
    //        set { result = value; }
    //    }
    //    public string Name
    //    {
    //        get { return methodName; }
    //        set { methodName = value; }
    //    }
    //}
}
