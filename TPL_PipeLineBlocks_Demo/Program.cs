//using System.Threading.Tasks.Dataflow;

//namespace TPL_PipeLineBlocks_Demo
//{
   
//        internal class Program
//        {
//            static async Task Main(string[] args)
//            {
//                string? inputFilePath = "input.txt";
//                string? outputFilePath = "output.txt";

//                // Create the dataflow blocks

//                // 1. Reading block: Reads lines from the input file asynchronously.
//                var readBlock = new TransformBlock<string, string>(
//                    async filePath =>
//                    {
//                        try
//                        {
//                            string fileContent = await File.ReadAllTextAsync(inputFilePath);
//                            //using (var reader = new StreamReader(filePath))
//                            //{
//                            //    var content = await reader.ReadToEndAsync();
//                            //    return content;
//                            //}
//                            return fileContent;
//                        }
//                        catch (Exception ex)
//                        {
//                            Console.WriteLine($"Error reading file: {ex.Message}");
//                            throw;
//                        }
//                    },
//                    new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 });
//                // 2. Processing block: Processes the file data (e.g., converting to uppercase).
//                var processBlock = new TransformBlock<string, string>(
//                    async data =>
//                    {
//                        // Simulate async processing
//                        await Task.Delay(100);
//                        await File.WriteAllTextAsync(outputFilePath, data.ToUpper());
//                        // Simulate a delay for the async process
//                        return data; // Example: Convert text to uppercase
//                    },
//                    new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 4 });
//                // 3. Writing block: Writes the processed data to the output file asynchronously.
//                var writeBlock = new ActionBlock<string>(
//                    async processedData =>
//                    {
//                        try
//                        {
//                            await File.WriteAllTextAsync(outputFilePath, processedData);
//                            //using (var writer = new StreamWriter(outputFilePath, append: false))
//                            //{
//                            //    await writer.WriteAsync(processedData);
//                            //}
//                        }
//                        catch (Exception ex)
//                        {
//                            Console.WriteLine($"Error reading file: {ex.Message}");
//                            throw;
//                        }

//                    },
//                    new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 });

//                // Link the blocks together
//                readBlock.LinkTo(processBlock, new DataflowLinkOptions { PropagateCompletion = true });
//                processBlock.LinkTo(writeBlock, new DataflowLinkOptions { PropagateCompletion = true });
//                var success = readBlock.Post(inputFilePath);
//                if (!success)
//                {
//                    Console.WriteLine("Failed to post the file path to the reading block.");
//                }
//                // Post the file to read
//                readBlock.Post(inputFilePath);

//                // Mark the head of the pipeline as complete
//                readBlock.Complete();

//                // Wait for the entire pipeline to complete
//                writeBlock.Complete();

//                Console.WriteLine("Pipeline execution completed.");
//            }
//        }
//    }


