namespace ShapeAreaApp
{
    public class Triangle : IShape
    {
        public double TBase { get; set; }
        public double THeight { get; set; }

        public Triangle() { }

        public Triangle(double tBase, double tHeight)
        {
            TBase = tBase;
            THeight = tHeight;
        }

        public double CalculateArea()
        {
            return 0.5 * TBase * THeight;
        }
    }
}
