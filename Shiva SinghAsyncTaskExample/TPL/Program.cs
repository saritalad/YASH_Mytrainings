using System.Reflection.Metadata;

namespace TPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks=new Task[3];
            //tasks[0]= Task.Run(()=>PerformTask("task0"));
            //tasks[1] = Task.Run(() => PerformTask("task1"));
            //tasks[2] = Task.Run(() => PerformTask("task2"));
            // Task.WaitAll(tasks);
            Parallel.For(0, 2,i=> { PerformTask("task" + i); });
        }
        static void PerformTask(string taskname )
        {
            Console.WriteLine($"{taskname} is running");
            Task.Delay(2500).Wait();
            Console.WriteLine($"{taskname} is completed.");
        }
    }
}
