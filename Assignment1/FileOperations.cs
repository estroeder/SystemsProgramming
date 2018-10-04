using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    internal class FileOperations
    {
        public List<string> GetFileContents(string fileName = "")
        {
            while(File.Exists($@"...\\...\\{fileName}") == false)
            {
                if(fileName != "")
                {
                    Console.Write("File not found. ");
                }
                Console.WriteLine("Please enter a valid file to open: ");

                fileName = Console.ReadLine();
            }

            return new List<string>(File.ReadAllLines($@"...\\...\\{fileName}"));
        }
    }
}