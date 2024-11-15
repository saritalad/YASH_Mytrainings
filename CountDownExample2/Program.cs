namespace CountDownExample2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int delayTimeInSeconds = 0;
            Console.WriteLine($"Program started at: {DateTime.Now.ToString("hh:mm ss tt")}");

            CountdownEvent countdownEvent = new CountdownEvent(3);

            for (int i = 1; i <= 3; i++)
            {
                _ = Task.Run(async () =>
                {
                    delayTimeInSeconds += 2;
                    await Task.Delay(TimeSpan.FromSeconds(delayTimeInSeconds));
                    Console.WriteLine($"Task completed at {DateTime.Now.ToString("hh:mm ss tt")}");

                }).ContinueWith(t =>
                {
                    countdownEvent.Signal();
                });
            }

            Console.WriteLine("Initialized all tasks. Waiting for their completion");
            countdownEvent.Wait();

            Console.WriteLine("Program Completed");
        }
    }
}