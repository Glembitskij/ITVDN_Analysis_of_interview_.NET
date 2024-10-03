// Принцип заміщення Лісков.
// Якщо об’єкт базового класу замінити об’єктом його похідного класу,
// то програма має продовжувати працювати коректно.

using before = BeforeRefactoring;
using after = AfterRefactoring;

before.SeniorDev senior1 = new before.SeniorDev();
before.JuniorDev junior1 = new before.JuniorDev();

before.Developer[] developers1 = new before.Developer[] { senior1, senior1 };
DevStartWork(developers1);

Console.WriteLine(new string('-', 30));

after.SeniorDev senior2 = new after.SeniorDev();
after.JuniorDev junior2 = new after.JuniorDev();

after.ICode[] codes = new after.ICode[] { senior2, junior2 };
DevStartWriteCode(codes);

after.IMeet[] meets = new after.IMeet[] { senior2 };
DevStartMeet(meets);

static void DevStartWork(before.Developer[] developers)
{
    foreach (var dev in developers)
    {
        dev.WriteCode();
        dev.MeetWithClient();
    }
}

static void DevStartWriteCode(after.ICode[] developers)
{
    foreach (after.ICode dev in developers)
    {
        dev.WriteCode();
    }
}

static void DevStartMeet(after.IMeet[] developers)
{
    foreach (after.IMeet dev in developers)
    {
        dev.MeetWithClient();
    }
}


namespace BeforeRefactoring
{
    public abstract class Developer
    {
        public virtual void WriteCode()
        {
            Console.WriteLine("WriteCode");
        }

        public virtual void MeetWithClient()
        {
            Console.WriteLine("MeetWithClient");
        }
    }

    public class SeniorDev : Developer
    {
        public override void WriteCode()
        {
            Console.WriteLine("SeniorDev write code");
        }

        public override void MeetWithClient()
        {
            Console.WriteLine("SeniorDev meet with client");
        }
    }

    public class JuniorDev : Developer
    {
        public override void WriteCode()
        {
            Console.WriteLine("JuniorDev write code");
        }

        public override void MeetWithClient()
        {
            throw new NotImplementedException("Junior does not hold meetings with the customer!");
        }
    }
}

namespace AfterRefactoring
{
    interface ICode
    {
        void WriteCode();
    }

    interface IMeet
    {
        void MeetWithClient();
    }

    public class SeniorDev : ICode, IMeet
    {
        public void WriteCode()
        {
            Console.WriteLine("SeniorDev write code");
        }

        public void MeetWithClient()
        {
            Console.WriteLine("SeniorDev meet with client");
        }
    }

    public class JuniorDev : ICode
    {
        public void WriteCode()
        {
            Console.WriteLine("JuniorDev write code");
        }
    }
}