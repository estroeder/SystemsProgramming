using System;
using System.Collections.Generic;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SYMS = "SYMS.dat";
            FileOperations fileOperations = new FileOperations();
            SymsProcessor symsProcessor = new SymsProcessor();

            // Process the contents of SYMS.dat
            List<string> symsContents = fileOperations.GetFileContents(SYMS);

            // Process SYMS File
            BinarySearchTree symbolTable = symsProcessor.Process(symsContents);

            Console.ReadKey();

            // Display the Symbol table
            symbolTable.View();

            Console.ReadKey();
        }
    }
}
