// 1. Що виведеться на консоль в результаты роботи метода ChangeCarBrand ? Чому, щоб вивелось, якби Car був структурою?
// 2. Що виведеться на консоль в результаты роботи метода IncreaseSpeed ? Чому ?
// 3. Чи правильно выдпрацює метод ReplaceCar, який модифікатор доступу потрібно додати, щоб метод відпрацював корректно?


Car myCar = new Car("Toyota", 60);
Console.WriteLine($"Початкові дані автомобіля: {myCar}");

ChangeCarBrand(myCar, "BMW");
Console.WriteLine($"Після зміни марки: {myCar}");

Console.WriteLine(new string('-', 30));

IncreaseSpeed(myCar, 20);
Console.WriteLine($"Після збільшення швидкості: {myCar}");

Console.WriteLine(new string('-', 30));

ReplaceCar(myCar);
Console.WriteLine($"Після заміни автомобіля: {myCar}");

static void ChangeCarBrand(Car car, string newBrand)
{
    car.Brand = newBrand;
}

static void IncreaseSpeed(Car car, int increaseAmount)
{
    car.Speed += increaseAmount;
}

static void ReplaceCar(Car car)
{
    car = new Car("Audi", 0);
}

public class Car
{
    public string Brand { get; set; }
    public int Speed { get; set; }

    public Car(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }

    public override string ToString()
    {
        return $"Brand: {Brand}, Speed: {Speed}";
    }
}