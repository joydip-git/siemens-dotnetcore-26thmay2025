// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CalDel cdAdd = new CalDel(Add);

Calculation calc = new();
CalDel cdSub = new CalDel(calc.Subtract);

CalDel cdMulti = Calculation.Multiply;

//cdAdd(12, 3);
//cdSub.Invoke(12, 3);
//cdMulti(12,3);
InvokeMethod(cdAdd);
InvokeMethod(cdSub);
InvokeMethod(cdMulti);

static void InvokeMethod(CalDel cd)
{
    cd(12,3);
}
static void Add(int x, int y) => Console.WriteLine(x + y);

delegate void CalDel(int a, int b);

class Calculation
{
    public void Subtract(int a, int b) => Console.WriteLine(a - b);

    public static void Multiply(int a, int b) => Console.WriteLine(a * b);
}
