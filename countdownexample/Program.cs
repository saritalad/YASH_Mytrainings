using System;
using System.Threading;
using System.Threading.Tasks;
namespace countdownexample
{
    class Program
    {
        static CountdownEvent countdown = new CountdownEvent(3);

        static void Main()
        {
            // Create multiple tasks
            Task[] tasks = new Task[3];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Simulate some work
                    // Thread.Sleep(1000);
                    Task.Delay(1000);
                    // Signal the countdown
                    countdown.Signal();
                    Console.WriteLine($"Task {i} has completed.");
                });
                
            }

            // Wait for all tasks to complete
            countdown.Wait();
            Console.WriteLine("All tasks have completed.");
        }
    }
}