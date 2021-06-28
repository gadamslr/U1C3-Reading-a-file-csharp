using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Need to ensure this namespace is used when using StreamReader / StreamWriter

namespace U1C3_Reading_a_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string documentLocation = "U:\\WriteLines.txt"; // Identify where you want to write the file
            string myText;

            // Writing to a file
            WriteToFile(documentLocation); // Calling method - passing file location

            // Appending to a file
            Console.WriteLine("Add something to your file: ");
            myText = Console.ReadLine();
            AppendToFile(documentLocation, myText); // Calling method

            // Reading a file
            ReadAFile(documentLocation);
            
            // Ensuring console does not close straight after program run
            Console.ReadLine();
        }

        static void WriteToFile(string docPath)
        {
            // In this example we will use StreamWriter to write to and read from a file
            // StreamWriter is a Class that allows for writing to a file

            using (StreamWriter sw = new StreamWriter(docPath)) // Instantiate sw object to write with
            // It is best practice to use using statement so that the unmanaged resources are correctly disposed
            {
                // Creating a sting array
                string[] lines =
                {
                    "First line", "Second line", "Third line"
                };

                foreach (var item in lines) // Iterates through each element in lines array
                {
                    sw.Write(item + "\n"); // Escape character
                }

                sw.WriteLine("Fourth Line" + "\n"); // Writing an additional line
            }
        }

        static void AppendToFile(string docPath, string newText)
        {
            StreamWriter sw = new StreamWriter(docPath, append: true);

            sw.WriteLine(newText + "\n");

            sw.Close(); // Closing the current StreamWriter object  when not using 'using'
        }

        static void ReadAFile(string docPath)
        {
            string line = "";
            StreamReader sr = new StreamReader(docPath);

            while ((line = sr.ReadLine()) != null) // Iteration - Reading each line 
                                                   // of file until there are no more 
                                                   // lines to read
            {
                Console.WriteLine(line); // Writes line to the console
            }
        }
    }
}
