using System.Threading.Tasks.Dataflow;

namespace AsyncFileReading_Demo
{
    internal class Program1
    {
        //static async Task Main()
        //{
        //    // Create a StreamWriter object for writing a text file
        //    using StreamWriter writer = new StreamWriter("output.txt");
        //    // Create a Random object for generating random numbers
        //    Random random = new();

        //    // Write 10 lines of random numbers to the file
        //    for (int i = 0; i < 10; i++)
        //    {
        //        // Generate a random number between 1 and 100
        //        int number = random.Next(1, 101);

        //        // Write the number followed by a line terminator asynchronously
        //        await writer.WriteLineAsync(number.ToString());
        //    }

        //    // Flush any buffered data to the file asynchronously
        //    await writer.FlushAsync();
        //    var batchBlock = new BatchBlock<string>(50);
        //    var sourceBlock = new BufferBlock<int>();
        //    var targetBlock = new ActionBlock<string>(result => Console.WriteLine(result));
        //    var propagatorBlock = new TransformBlock<int, string>(input => (input * 2).ToString());

        //}
    }
}
