using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL_PipeLineBlocks_Demo
{
    internal class BufferBlockTransformBlockActionBlock
    {
        static async Task Main(string[] args)
        {
            string inputFilePath = "input.txt";  // Path to the input file
            string outputFilePath = "output.txt"; // Path to the output file

            // 1. Create a BufferBlock that will hold  text file
            var bufferBlock = new BufferBlock<string>();

            // 2. Asynchronously read the file and post the BufferBlock
            Task readFileTask = Task.Run(async () =>
            {
                // Mutex should be used multiple exe running at a time.
                try
                {
                    string fileContent = await File.ReadAllTextAsync(inputFilePath);
                    await bufferBlock.SendAsync(fileContent);
                    // Mark the BufferBlock as complete after all lines have been read
                    bufferBlock.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                   // bufferBlock.Fault(ex); // Mark the block as faulted if there's an exception
                }
            });

            // 3. Create a TransformBlock to convert each line to uppercase
            var transformBlock = new TransformBlock<string, string>(
                line => line.ToUpper(), // Transform the line to uppercase
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 4 } // Parallelize transformation if needed
            );

            // 4. Create an ActionBlock to write each transformed line to the output file
            var writeBlock = new ActionBlock<string>(
                async transformedLine =>
                {
                    // Asynchronously write each transformed file the output file
                    try
                    {
                        // Append each line to the output file
                        await File.WriteAllTextAsync(outputFilePath, transformedLine + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error writing to file: {ex.Message}");
                    }
                });

            // 5. Link the BufferBlock to the TransformBlock
            bufferBlock.LinkTo(transformBlock, new DataflowLinkOptions { PropagateCompletion = true });

            // 6. Link the TransformBlock to the ActionBlock (writing block)
            transformBlock.LinkTo(writeBlock, new DataflowLinkOptions { PropagateCompletion = true });

            // 7. Wait for the read task and writing to complete
           // await Task.WhenAll(readFileTask, writeBlock.Completion);

            Console.WriteLine("File reading, transformation, and writing completed.");

        }
    }
}