//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TPL_PipeLineBlocks_Demo
//{
//    internal class ReadFile
//    {
//        static async Task Main()
//        {
//            string inputFilePath = "input.txt";

//            try
//            {
//                // Reading the entire file asynchronously
//                string fileContent = await File.ReadAllTextAsync(inputFilePath);
//                Console.WriteLine(fileContent); // Print the entire file content to the console
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error reading file: {ex.Message}");
//            }
//        }
//        }
//}
