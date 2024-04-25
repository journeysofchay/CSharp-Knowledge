using System;
using System.Threading;

public class ThreadSafeCounter
{
    private int count = 0;
    private readonly object lockObject = new object();

    public void Increment()
    {
        lock (lockObject)
        {
            count++;
            Console.WriteLine($"Incremented. Current count: {count}");
        }
    }

    public void Decrement()
    {
        lock (lockObject)
        {
            count--;
            Console.WriteLine($"Decremented. Current count: {count}");
        }
    }

    private void IncrementThreadLogic()
    {
        for (int i = 0; i < 5; i++)
        {
            Increment();
            Thread.Sleep(100);
        }
    }

    private void DecrementThreadLogic()
    {
        for (int i = 0; i < 5; i++)
        {
            Decrement();
            Thread.Sleep(100);
        }
    }

    public void RunThreads()
    {
        Thread thread1 = new Thread(IncrementThreadLogic);
        Thread thread2 = new Thread(DecrementThreadLogic);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}

public class Program
{
    public static void Main()
    {
        ThreadSafeCounter counter = new ThreadSafeCounter();

        counter.RunThreads();

        Console.WriteLine("Final count: " + counter.Count);
    }
}
