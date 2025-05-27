namespace ShapeAreaApp
{
    internal class Program
    {
        static void Main()
        {
            IShape[] shapes =
                [
                new Circle{ Radius=12 },
                new Triangle{ TBase=12, THeight=3}
                ];
            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area of {shape.GetType().Name} is {shape.CalculateArea()}");
            }
        }
    }
}
