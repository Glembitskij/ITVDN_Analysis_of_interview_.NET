// 1. Чи правильно відпрапрацює метод MoveAlongHorizontalPlane, якщо ні, то яким чином це можна виправити ?
// 2. Чи коректно выдпрацює метод ResetPoint, якщо ні яким чином це можна виправити ? 
// 3. Чи можна оптимізувати роботу метода ShowPoint, яким чином ?
// 4. Яким чином передаються аргументи в методи ? 

Point point = new Point(10, 10);
Console.WriteLine(point.ToString());

MoveAlongHorizontalPlane(point, 5);

Console.WriteLine(point.ToString());

Console.WriteLine(new string('-', 30));

ResetPoint(point);

Console.WriteLine(point.ToString());

Console.WriteLine(new string('-', 30));

ShowPoint(point);

// Метод для зміни коррдинати точки по осі х
static void MoveAlongHorizontalPlane(Point point, int value)
{
    point.X += value;
}

// Метод для "скидування" кординати
static void ResetPoint(Point point)
{
    point = new Point(0, 0);
}

//Метод для відображення кооординати
static void ShowPoint(Point point)
{
    Console.WriteLine(point.ToString());
}

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";
}
