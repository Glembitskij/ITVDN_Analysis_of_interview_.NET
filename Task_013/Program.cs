// Принцип інверсії залежностей (Dependency Inversion Principle)

//Book book = new Book(new ConsolePrinter());
//Book book = new Book() { Printer = new ConsolePrinter() };

Book book = new Book();

book.Print(new ConsolePrinter());
//book.Printer = new HtmlPrinter();
book.Print(new ConsolePrinter());

interface IPrinter
{
    void Print(string text);
}

class Book
{
    public string Text { get; set; }

    // Використання залежностей через властивості(Property Injection)
    //private IPrinter printer;

    //public IPrinter Printer 
    //{ 
    //    get { return printer; }
    //    set { printer = value; } 
    //}

    //// Використання залежностей через конструктор (Constructor Injection)
    //public Book(IPrinter printer)
    //{
    //    this.Printer = printer;
    //}

    // Внедрение зависимостей через метод (Method Injection)
    public void Print(IPrinter Printer)
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
