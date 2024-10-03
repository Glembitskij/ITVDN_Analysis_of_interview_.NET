// Що буде виведено на консоль? 
// Чи буде створбватись для кожного потоку нова купа та стек ?

ThreadStart write = new ThreadStart(Write);

Thread thread = new Thread(write);
thread.Start();

Write();

Console.ReadKey();

static void Write()
{
    int counter = 0;

    while (counter < 10)
    {
        Console.WriteLine($"counter = {counter} - thread - {Thread.CurrentThread.ManagedThreadId}");
        counter++;
    }
}