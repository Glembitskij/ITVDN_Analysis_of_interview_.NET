// Принцип відкритості/закритості
// Класи мають бути відкриті до розширення, але закриті для змін.
// Якщо є клас, функціонал якого передбачає чимало розгалужень або
// багато послідовних кроків, і є великий потенціал,
// що їх кількість буде збільшуватись, то потрібно спроєктувати клас таким чином,
// щоб нові розгалуження або кроки не призводили до його модифікації.

using before = BeforeRefactoring;
using after = AfterRefactoring;

before.Square square1 = new before.Square() { Side = 10 };
before.Circle circle1 = new before.Circle() { Radius = 10 };
before.Rectangle rectangle1 = new before.Rectangle() { Height = 5, Width = 10 };

Object[] objects = new Object[] { square1, circle1, rectangle1 };

before.AreaCalculator areaCalculator1 = new before.AreaCalculator();
double totalArea1 = areaCalculator1.CalculateTotalArea(objects);

Console.WriteLine(totalArea1);

new string('-', 30);

after.Square square2 = new after.Square() { Side = 10 };
after.Circle circle2 = new after.Circle() { Radius = 10 };
after.Rectangle rectangle2 = new after.Rectangle() { Height = 5, Width = 10 };

after.IShape[] iShape = new after.IShape[] { square2, circle2, rectangle2 };

after.AreaCalculator areaCalculator2 = new after.AreaCalculator();
double totalArea2 = areaCalculator2.CalculateTotalArea(iShape);

Console.WriteLine(totalArea2);


namespace BeforeRefactoring
{
    class Square
    {
        public int Side { get; set; }
    }

    class Circle
    {
        public int Radius { get; set; }
    }

    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class AreaCalculator
    {
        public double CalculateTotalArea(Object[] rectangles)
        {
            double results = 0;

            foreach (var figure in rectangles)
            {
                if (figure is Square)
                {
                    Square square = (Square)figure;
                    results += Math.Pow(square.Side, 2);
                }
                else if (figure is Circle)
                {
                    Circle circle = (Circle)figure;
                    results += Math.Pow(circle.Radius, 2) * Math.PI;

                }
                else if (figure is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)figure;
                    results += rectangle.Height * rectangle.Width;
                }
            }

            return results;
        }
    }
}

namespace AfterRefactoring
{
    public interface IShape
    {
        double CalculateArea();
    }

    class Square : IShape
    {
        public int Side { get; set; }

        public double CalculateArea()
        {
            return Math.Pow(Side, 2);
        }
    }

    class Circle : IShape
    {
        public int Radius { get; set; }

        public double CalculateArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }

    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class AreaCalculator
    {
        public double CalculateTotalArea(IShape[] rectangles)
        {
            double results = 0;

            foreach (var figure in rectangles)
            {
                results += figure.CalculateArea();
            }

            return results;
        }
    }
}
