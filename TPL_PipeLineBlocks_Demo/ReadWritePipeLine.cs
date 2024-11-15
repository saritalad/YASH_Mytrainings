//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;

//namespace TPL_PipeLineBlocks_Demo
//{
//    internal class ReadWritePipeLine
//    {
//        static async Task Main(string[] args)
//        {
//            // Create a BufferBlock, which acts as a source block
//            var bufferBlock = new BufferBlock<int>();

//            // Post some data into the buffer (acts as the source of data)
//            bufferBlock.Post(10);
//            bufferBlock.Post(20);
//            bufferBlock.Post(30);

//            // Create a TransformBlock that consumes data from the source
//            var transformBlock = new TransformBlock<int, string>(
//                number => $"Number squared: {number * number}");

//            // Link the source block (bufferBlock) to the processing block (transformBlock)
//            bufferBlock.LinkTo(transformBlock, new DataflowLinkOptions { PropagateCompletion = true });

//            // Mark the buffer block as complete once all data has been posted
//            bufferBlock.Complete();

//            // Retrieve and print the transformed data from the transform block
//            while (await transformBlock.OutputAvailableAsync())
//            {
//                Console.WriteLine(await transformBlock.ReceiveAsync());
//            }
//        }
//    }
//}