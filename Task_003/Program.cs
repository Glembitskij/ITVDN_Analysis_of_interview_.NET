// Що таке Інкапсуляція, наведіть приклад та наведіть приклад порушення інкапсуляції. 

// Інкапсуляція — це принцип ООП, який полягає в приховуванні
// деталей реалізації об'єктів від «зовнішнього світу».
// Цей принцип стверджує, що вся важлива інформація міститься
// всередині об’єкта, а назовні доступна тільки вибрана інформація. 

Document document = new Document();
document.CreateDocument();

internal class Document
{
    public void CreateDocument()
    {
        CreateHeader();
        CreateBody();
        CreateSignature();
    }

    private void CreateHeader()
    {
        Console.WriteLine("CreateHeader");
    }

    private void CreateBody()
    {
        Console.WriteLine("CreateBody");
    }

    private void CreateSignature()
    {
        Console.WriteLine("CreateSignature");
    }
}