//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TPL_PipeLineBlocks_Demo
//{
//    internal class ReadWrite
//    {
//        public static async Task Main()
//        {
//            string inputFilePath = "input.txt";
//            string outputFilePath = "output.txt";

//            try
//            {
//                // Asynchronously read the entire content of input.txt
//                string fileContent = await File.ReadAllTextAsync(inputFilePath);
//                Console.WriteLine("File content read successfully.");

//                // Asynchronously write the content to output.txt
//                await File.WriteAllTextAsync(outputFilePath, fileContent.ToUpper());
//                Console.WriteLine("File content written to output.txt successfully.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//        }
//    }
//}
