using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class ParseLiteralOrExpression
    {
        public void Parse(List<string> expressionList, List<string> literalList, List<string> expresionFileContents)
        {
            for (int i = 0; i < expresionFileContents.Count; i++)
            {
                int lineNumber = i + 1;

                // Trim the line
                List<string> trimmedLine = TrimLineContents(expresionFileContents[i]);

                if (trimmedLine.Count < 2)
                {
                    // Evaluate if it is an expression or a literal
                    SetLiteralOrExpression(expressionList, literalList, trimmedLine.First());
                }
                else
                {
                    Console.WriteLine($"Error in expressions file on line { lineNumber}, there were { trimmedLine.Count} parameters found, only 1 is allowed (expression/literal).");
                }
            }
        }

        private List<string> TrimLineContents(string line)
        {
            return new List<string>(line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries));
        }

        private void SetLiteralOrExpression(List<string> expressionList, List<string> literalList, string expressionToEvaluate)
        {
            if (expressionToEvaluate[0] == '=')
            {
                literalList.Add(expressionToEvaluate);
            }
            else
            {
                expressionList.Add(expressionToEvaluate);
            }
        }
    }
}