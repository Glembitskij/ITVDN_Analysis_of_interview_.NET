// Яким чином можна сгенерувати виключення ?
// Чи оптимально в данному коді згенероване виключення ?
// Яким чином можна створити користувацьке виключення ?
// В чому різниця між throw, throw exp, throw new Exception();

try
{
    HumanGeneration.GetNewLifePerson(300);
}
catch (Exception exp)
{
    Console.WriteLine(exp.StackTrace);
}


class Person
{
    public int Pulse { get; set; }

    public void Life()
    {
        if (Pulse > 250 || Pulse < 50)
        {
            throw new Exception("");
        }
    }
}

class HumanGeneration
{
    public static Person GetNewLifePerson(int pulse)
    {
        Person person;
        try
        {
            person = new Person { Pulse = pulse };
            person.Life();
        }
        catch (Exception exp)
        {
            //throw;
            //throw exp;
            throw new Exception();
        }

        return person;
    }
}