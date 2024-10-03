// Принцип розділення інтерфейсів (Interface Segregation Principle, ISP)
// є одним з принципів SOLID і стверджує, що клас не повинен виживати методи,
// які він не використовує. Коли клас реалізує інтерфейс, інтерфейс повинен бути
// таким, щоб його клієнти знали лише ті методи, які їм дійсно потрібні.
using before = BeforeRefactoring;
using after = AfterRefactoring;

before.EmailMessage emailMessage1 = new before.EmailMessage();
emailMessage1.Voice = new byte[0];

after.EmailMessage emailMessage2 = new after.EmailMessage();
//emailMessage2.Voice = new byte[0];

namespace BeforeRefactoring
{
    interface IMessage
    {
        void Send();
        string Text { get; set; }
        string Subject { get; set; }
        string ToAddress { get; set; }
        string FromAddress { get; set; }
        byte[] Voice { get; set; }
    }

    class EmailMessage : IMessage
    {
        public string Subject { get; set; } = "";
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public byte[] Voice
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Send()
        {
            Console.WriteLine($"Отправляем Email-сообщение: {Text}");
        }
    }

    class SmsMessage : IMessage
    {
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public string Subject
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public byte[] Voice
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Send()
        {
            Console.WriteLine($"Отправляем Sms-сообщение: {Text}");
        }
    }

    class VoiceMessage : IMessage
    {
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public byte[] Voice { get; set; } = new byte[] { };

        public string Text
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Subject
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Send()
        {
            Console.WriteLine("Передача голосовой почты");
        }
    }
}

namespace AfterRefactoring
{
    interface IMessage
    {
        void Send();
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }

    interface IVoiceMessage : IMessage
    {
        byte[] Voice { get; set; }
    }

    interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }

    interface IEmailMessage : IMessage
    {
        string Text { get; set; }
        string Subject { get; set; }
    }

    class VoiceMessage : IVoiceMessage
    {
        public string ToAddress { get; set; } = "";

        public string FromAddress { get; set; } = "";

        public byte[] Voice { get; set; } = Array.Empty<byte>();

        public void Send()
        {
            Console.WriteLine("Передача голосовой почты");
        }
    }

    class EmailMessage : IEmailMessage
    {
        public string Text { get; set; } = "";
        public string Subject { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public void Send()
        {
            Console.WriteLine("Отправляем по Email сообщение: {Text}");
        }
    }

    class SmsMessage : ITextMessage
    {
        public string Text { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public void Send()
        {
            Console.WriteLine("Отправляем по Sms сообщение: {Text}");
        }
    }

}