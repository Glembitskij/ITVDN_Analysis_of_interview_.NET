// Чи можна покращити данний код, якщо так, то яким чином 
// Яким чином видаляються єеземпляри классу з купи ?
// Що таке garbage collector, як він працює ?

using (Person person = new Person("Peta"))
{
    Console.WriteLine(person.Name);
}
//person.Dispose();

class Person : IDisposable
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public void Dispose()
    {
        Console.WriteLine("Person dispose");
    }
}