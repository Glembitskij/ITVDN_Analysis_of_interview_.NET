// Принцип інверсії залежностей (Dependency Inversion Principle)
// Cкладається з двох тверджень:

// високорівневі модулі не повинні залежати від низькорівневих.
// І ті, і ті мають залежати від абстракцій;
// Aбстракції не мають залежати від деталей реалізації.
// Деталі реалізації повинні залежати від абстракцій.

using before = BeforeRefactoring;
using after = AfterRefactoring;

before.ConsolePrinter consolePrinter1 = new before.ConsolePrinter();

before.Book book1 = new before.Book() { Text = "C# book", Printer = consolePrinter1 };
book1.Print();

Console.WriteLine(new string('-', 30));

after.Book book2 = new after.Book(new after.ConsolePrinter());
book2.Print();

book2.Printer = new after.HtmlPrinter();
book2.Print();

namespace BeforeRefactoring
{
    class Book
    {
        public string? Text { get; set; }
        public ConsolePrinter? Printer { get; set; }

        public void Print()
        {
            Printer?.Print(Text);
        }
    }

    class ConsolePrinter
    {
        public void Print(string? text)
        {
            Console.WriteLine(text);
        }
    }
}

namespace AfterRefactoring
{
    interface IPrinter
    {
        void Print(string text);
    }

    class Book
    {
        public string Text { get; set; }
        public IPrinter Printer { get; set; }

        // Використання залежностей через конструктор (Constructor Injection)
        public Book(IPrinter printer)
        {
            this.Printer = printer;
        }

        public void Print()
        {
            Printer.Print(Text);
        }
    }

    class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать на консоли");
        }
    }

    class HtmlPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать в html");
        }
    }
}