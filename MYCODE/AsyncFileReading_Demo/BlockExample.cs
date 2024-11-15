using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace AsyncFileReading_Demo
{//https://medium.com/codex/the-magic-of-net-data-flow-27f0120808ee
    internal class BlockExample
    {
        //static async Task Main()
        //{
        //    // Create our action block.
        //    var block = new ActionBlock<int>(async number =>
        //    {
        //        await Task.Delay(1000);
        //        Console.WriteLine($"Processed number: {number}");
        //    });

        //    // Post data to the pipeline.
        //    for (int i = 0; i < 10; i++)
        //    {
        //        block.Post(i);
        //    }

        //    block.Complete();

        //    //Await the pipeline complition.
        //    await block.Completion;

        //    //Run post-pipeline code.
        //    Console.WriteLine("All numbers processed.");
        //}
    }
}
