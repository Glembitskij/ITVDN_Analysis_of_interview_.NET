// Які типів зв’язків (відношень) ви занєте?

#region Реалізація
// 1. Реалізація (Інтерфейсна реалізація)
// Це відношення показує, що клас реалізує контракт, визначений інтерфейсом,
// і повинен забезпечити реалізацію всіх методів інтерфейсу.

interface IVehicle
{
    void Drive();
}

class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is driving.");
    }
}
#endregion

#region Наслідування 
// 2. Наслідування є відношенням, у якому один клас (Child) успадковує властивості та методи іншого класу (Parent).
// Це дозволяє повторно використовувати код і розширювати функціональність.

class Animal
{
    public void Eat()
    {
        Console.WriteLine("The animal is eating.");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("The dog is barking.");
    }
}
#endregion

#region Асоціація 
// 3. Асоціація — це слабкий тип зв'язку між двома класами, де один клас використовує інший.
// Це означає, що об'єкти одного класу можуть взаємодіяти з об'єктами іншого, але вони не мають відношення власності.
// Це може бути як односторонній, так і двосторонній зв'язок.

class Teacher
{
    public void Teach(Student student)
    {
        Console.WriteLine($"{student.Name} is being taught by the teacher.");
    }
}

class Student
{
    public string Name { get; set; }

    public Student(string name)
    {
        Name = name;
    }
}
#endregion

#region Композиція 
// 6. Композиція також представляє відношення "ціле-частина", але з більш сильним зв'язком, коли частини
// не можуть існувати окремо від цілого. Якщо "ціле" видаляється, то й "частини" знищуються разом з ним.
class Room
{
    public string RoomType { get; }

    public Room(string roomType)
    {
        RoomType = roomType;
    }
}

class House
{
    public List<Room> Rooms { get; } = new List<Room>();

    public House()
    {
        Rooms.Add(new Room("Bedroom"));
        Rooms.Add(new Room("Kitchen"));
    }
}
#endregion

#region Агрегація 
// 5. Агрегація є типом асоціації, який вказує на "ціле-частина" відношення, де один клас складається з
// одного або кількох екземплярів іншого класу. Однак, об'єкти, які належать "частині", можуть існувати незалежно від "цілого".
abstract class Player
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }
}

class Team
{
    public List<Player> Players { get; } = new List<Player>();

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }
}
#endregion