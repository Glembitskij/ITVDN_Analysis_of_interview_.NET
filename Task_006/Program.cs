// Що таке абстракція. Що таке інтерфейс, в чому різниця абстрактного классу та інтерфейсу. 

// Абстракція допомагає зосередитися на головних аспектах системи та
// ігнорувати менш важливі деталі, які не впливають на головні функції.
// Це дозволяє створювати більш зрозумілі програми.
// Абстракцію можна розглядати як розширення до інкапсуляції.

// Проблема (немає змоги при upCast достукатись до методу який визначенний
// в обох классах PaymentMethod, при цьому базової реалізації немає).

PaymentMethod[] payments =
    {
            new CreditCardPayment("1234-5678-9012-3456"),
            new CryptoPayment("0xABC123DEF456")
    };

decimal amount = 500;

foreach (var payment in payments)
{
    payment.ProcessPayment(amount);
}

abstract class PaymentMethod
{
    public abstract void ProcessPayment(decimal amount);
}

class CreditCardPayment : PaymentMethod
{
    private string cardNumber;

    public CreditCardPayment(string cardNumber)
    {
        this.cardNumber = cardNumber;
    }

    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Платіж {amount} грн здійснено за допомогою банківської картки {cardNumber}.");
    }
}

class CryptoPayment : PaymentMethod
{
    private string walletAddress;

    public CryptoPayment(string walletAddress)
    {
        this.walletAddress = walletAddress;
    }

    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Платіж {amount} грн здійснено через криптовалютний гаманець {walletAddress}.");
    }
}