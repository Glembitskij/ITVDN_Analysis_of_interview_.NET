// Які підходи існують для роботи з багатопотоковістю в Net ?
// Що таке пул потоків, яким чином з ним можна працювати ?

// 1. Використання Thread
ThreadStart threadStart = new ThreadStart(WriteInfo);

Thread thread = new Thread(threadStart);

thread.Start();

// Використання асинхронних делегатів 
//Action myDelegate = new Action(WriteInfo);

//// exception - https://github.com/dotnet/runtime/issues/16312
//myDelegate.BeginInvoke(null, null);

// Використання бібліотеки TPL, в якій лежить концепція задач
Action myDelegate = new Action(WriteInfo);

Task task = new Task(myDelegate);
task.Start();

static void WriteInfo()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Thread Id {Thread.CurrentThread.ManagedThreadId}, counter = {i}");
    }
}