namespace SafariPark
{
    public abstract class IShape
    {
        public abstract int CalculateArea();

        public override string ToString()
        {
            return "This is a shape";
        }
    }

    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int CalculateArea()
        {
            return Width * Height;
        }
    }
}
