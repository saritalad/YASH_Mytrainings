//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;

//namespace TPL_PipeLineBlocks_Demo
//{
//    internal class BufferBlockDemo
//    {
//        static async Task Main(string[] args)
//        {
//            string inputFilePath = "input.txt"; // Path to the input file
//            string outputFilePath = "output.txt";
//            // 1. Create a BufferBlock that will hold lines from the text file
//            var bufferBlock = new BufferBlock<string>();

//            // 2. Asynchronously read the file and post lines to the BufferBlock
//            Task readFileTask = Task.Run(async () =>
//            {
//                try
//                {
//                    using (var reader = new StreamReader(inputFilePath))
//                    {
//                        string? line;
//                        while ((line = await reader.ReadLineAsync()) != null)
//                        {
//                            // Post each line of the file to the BufferBlock
//                            await bufferBlock.SendAsync(line.ToUpper());
//                        }
//                    }

//                    // Mark the BufferBlock as complete after all lines have been read
//                    bufferBlock.Complete();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error reading file: {ex.Message}");
//                   // bufferBlock.Fault(ex); // Mark the block as faulted if there's an exception
//                }
//            });

//            // 3. Create an ActionBlock to write each line to the output file
//            var writeBlock = new ActionBlock<string>(
//                async line =>
//                {
//                    // Asynchronously write each line to the output file
//                    try
//                    {
//                        // Append each line to the output file
//                        await File.AppendAllTextAsync(outputFilePath, line + Environment.NewLine);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Error writing to file: {ex.Message}");
//                    }
//                });

//            // 4. Link the BufferBlock to the ActionBlock
//            bufferBlock.LinkTo(writeBlock, new DataflowLinkOptions { PropagateCompletion = true });

//            // 5. Wait for the read task and writing to complete
//            await Task.WhenAll(readFileTask, writeBlock.Completion);

//            Console.WriteLine("File reading and writing completed.");

//        }
//    }
//}