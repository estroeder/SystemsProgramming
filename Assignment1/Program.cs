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
            ParseLiteralOrExpression parser = new ParseLiteralOrExpression();
            ExpressionProcessor expressionProcessor = new ExpressionProcessor();
            LiteralProcessor literalProcessor = new LiteralProcessor();

            // Process the contents of SYMS.dat
            List<string> symsFileContents = fileOperations.GetFileContents(SYMS);

            // Process SYMS File
            BinarySearchTree symbolTable = symsProcessor.Process(symsFileContents);
            Console.ReadKey();

            // Display the Symbol table
            //symbolTable.View();
            //Console.ReadKey();

            // Process the contents of the expression file - Read file name from command line if it exists
            List<string> expressionFileContents;
            if(args.Length > 0)
            {
                expressionFileContents = fileOperations.GetFileContents(args[0]);
            }
            else
            {
                expressionFileContents = fileOperations.GetFileContents();
            }

            // Parse File contents into expressions and literals
            List<string> expressions = new List<string>();
            List<string> literals = new List<string>();
            parser.Parse(expressions, literals, expressionFileContents);

            // Process the expressions
            expressionProcessor.Process(expressions);
            Console.ReadKey();

            // Process the literals
            literalProcessor.Process(literals);
        }
    }
}
