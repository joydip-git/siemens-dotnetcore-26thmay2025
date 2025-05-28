namespace ExtensionLibrary;

using CalculationLibrary;


public static class Extensions
{
    public static int Subtract(this ICalculation cal, int a, int b)
    {
        return a - b;
    }
    public static string SayHello(this string str, string name)
    {
        return ($"Hello {name}!").ToUpper();
    }
}
