public class Program
{

    public class Shape{
        public const double PI = Math.PI;
        public required string Name { get; set; }
        public virtual double CalculateArea() {
            return 0;
        }
    }

    public class Circle : Shape{

        double _raduis;
        
        public Circle(double raduis) {
            _raduis = raduis;
        }
        public override double CalculateArea() {
            return PI * _raduis * _raduis;
        }
    
    }

    public class Rectangle : Shape{

        double _width;
        double _height;
        
        public Rectangle(double width, double height) {
            _width = width;
            _height = height;
        }
        public override double CalculateArea() {
            return _width * _height;
        }
    
    }

    public class Triangle : Shape{

        double _base;
        double _height;
        
        public Triangle(double baseT, double height) {
            _base = baseT;
            _height = height;
        }

        public override double CalculateArea() {
            return (_base * _height)/2;
        }
    
    }
    
    static void PrintShapeArea(Shape shape) {
        Console.WriteLine($"Shape: {shape.Name}");

        Console.WriteLine($"Shape: {shape.CalculateArea()}");

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Circle circle = new Circle(5) {Name = "Circle"};
        Rectangle rectangle = new Rectangle(5,2) {Name = "Rectangle"};
        Triangle triangle = new Triangle(5,5) {Name = "Triangle"};

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}   