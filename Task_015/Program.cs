// Яки не було циклу форич яким чином можна було б його замінити.
// Розкажіть про інтерфейс IEnumerable та IEnumerator
// Як цінити час пошуку та час пошуку вставки єлементу в коллекцію ?
// Яка складність вставки новогу єлементу в коллекцію List ?

using System.Collections;

List<Employee> employees = new List<Employee>()
{
    new Employee(){ Name = "Alex" },
    new Employee(){ Name = "Vasa" },
    new Employee(){ Name = "Peta" }
};

foreach (Employee employee in employees)
{
    Console.WriteLine(employee.Name);
}

IEnumerable enumerable = employees;
IEnumerator enumerator = enumerable.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.WriteLine((enumerator.Current as Employee)?.Name);
}

class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }
}