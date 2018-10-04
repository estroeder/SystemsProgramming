using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class BinarySearchTree
    {
        SortedSet<Symbol> binarySearchTree = new SortedSet<Symbol>();

        public bool Insert(Symbol symbol)
        {
            bool dupeFlag = binarySearchTree.Add(symbol);

            // If the node to be inserted returns false then it is a duplicate so the Mflag must be set to true
            if (dupeFlag == false)
            {
                Symbol dupeSymbol = Search(symbol.Label);
                dupeSymbol.Mflag = true;
            }

            return dupeFlag;
        }

        public Symbol Search(string label)
        {
            return binarySearchTree.FirstOrDefault(x => x.Label == label);
        }

        public void View()
        {
            Console.WriteLine("SYMBOL   -   VALUE   -   RFLAG - IFLAG - MFLAG");
            Console.WriteLine("----------------------------------------------");
            foreach (Symbol symbol in binarySearchTree)
            {
                Console.WriteLine($"{symbol.Label} - {symbol.Value} - {symbol.Rflag} - {symbol.IFlag} - {symbol.Mflag}");
            }
        }
    }
}