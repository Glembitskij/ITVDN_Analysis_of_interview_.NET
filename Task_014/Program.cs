// 1. Наприклад ви створюєте, бібліотеку, в якій є класс Employee та метод по
//    разрахунку зарплаті - CalculateSalary.
//    Також є необхідність мати змогу нотифікувати користувача про нарахування йому зарплатні,
//    але ці нотифікації можуть бути різними. Яким чином можна розробити такий механізм?

// 2. Що таке делагат
// 3. Що таке подія
// 4. В чому різниця між між делегатом та подією. 
// 5. Які системні делегати ви знаете?

Employee employee = new Employee();
employee.Notify += SendSms;

employee.CalculateSalary();

void SendSms()
{
    Console.WriteLine("SendSms");
}

class Employee
{
    public event Action Notify;

    public int CalculateSalary()
    {
        Random random = new Random();
        Notify.Invoke();
        return random.Next(1, 100);
    }
}