using System;
using System.Collections.Generic;

namespace Assignment1
{
    internal class SymsProcessor
    {
        BinarySearchTree symbolTree = new BinarySearchTree();
        ValidateLabel validateLabel = new ValidateLabel();
        ValidateValue validateValue = new ValidateValue();
        ValidateRflag validateRflag = new ValidateRflag();

        public BinarySearchTree Process(List<string> symsContents)
        {
            for (int i = 0; i < symsContents.Count; i++)
            {
                int lineNumber = i + 1;
                // Trim each line into individual contents
                List<string> trimmedLine = TrimLineContents(symsContents[i]);

                if (trimmedLine.Count == 3)
                {
                    // Process each item in the line
                    Symbol symbol = ProcessLineContents(trimmedLine, lineNumber);

                    if (symbol.IsValid)
                    {
                        // add to binary search tree
                        if (symbolTree.Insert(symbol) == false)
                        {
                            Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, '{symbol.Label}': Symbol was previous defined.");
                        }
                    }
                }
                else
                {
                    // Throw an error if there were not exactly three objects returned in the line
                    Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, there were {trimmedLine.Count} parameters found, only 3 are allowed (SYMBOL, VALUE, RFLAG).");
                }
            }

            return symbolTree;
        }

        private List<string> TrimLineContents(string line)
        {
            return new List<string>(line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries));
        }

        private Symbol ProcessLineContents(List<string> trimmedLine, int lineNumber)
        {
            Symbol newSymbol = new Symbol();

            // Validate the Label
            string label = validateLabel.Validate(trimmedLine[0], lineNumber);

            // Validate the Value
            int? value = validateValue.Validate(trimmedLine[0], trimmedLine[1], lineNumber);

            // Validate the Rflag
            bool? rflag = validateRflag.Validate(trimmedLine[0], trimmedLine[2], lineNumber);

            // If the symbol is completely valid, create a symbol node
            if (label != string.Empty && value != null && rflag != null)
            {
                newSymbol = new Symbol(label, Convert.ToInt32(value), Convert.ToBoolean(rflag));
            }

            return newSymbol;
        }
    }
}