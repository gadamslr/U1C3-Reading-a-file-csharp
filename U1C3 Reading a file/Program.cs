using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U1C3_Reading_a_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string documentLocation = "U:\\WriteLines.txt"; // Identify where you want to write the file
            string myText;

            // Writing to a file
            Writing(documentLocation);

            // Appending to a file
            Console.WriteLine("Add something to your file: ");
            myText = Console.ReadLine();
            AppendToFile(documentLocation, myText);

            // Reading a file
            ReadAFile(documentLocation);
            
            // Ensuring console does not close straight after program run
            Console.ReadLine();
        }

        static void Writing(string docPath)
        {
            // In this example we will use StreamWriter to write to and read from a file
            // StreamWriter is a Class that allows for writing to a file

            using (StreamWriter sw = new StreamWriter(docPath)) // Instantiate sw object to write with
            // It is best practice to use using statement so that the unmanaged resources are correctly disposed
            {
                string[] lines =
                {
                    "First line", "Second line", "Third line"
                };

                foreach (var item in lines)
                {
                    sw.Write(item + "\n");
                }

                sw.WriteLine("Fourth Line" + "\n");

                sw.Close();
            }

        }

        static void AppendToFile(string docPath, string newText)
        {
            StreamWriter sw = new StreamWriter(docPath, append: true);

            sw.WriteLine(newText + "\n");

            sw.Close();
        }

        static void ReadAFile(string docPath)
        {
            string line = "";
            StreamReader sr = new StreamReader(docPath);

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

    }
}
