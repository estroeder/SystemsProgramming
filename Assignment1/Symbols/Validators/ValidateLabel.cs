using System;
using System.Linq;

namespace Assignment1
{
    class ValidateLabel
    {
        public string Validate(string label, int lineNumber)
        {
            string validatedSymbol = string.Empty;
            // 1) Must start with a letter
            if (Char.IsLetter(label[0]))
            {
                // 2) Must be followed by alphanumeric or underscore
                if (label.All(c => Char.IsLetterOrDigit(c) || c.Equals('_')))
                {
                    // 3) Max 10 character
                    if (label.Length < 11)
                    {
                        // 3.5) If symbol is larger than 4 characters, truncate 4 characters
                        if (label.Length > 4)
                        {
                            validatedSymbol = label.Substring(0, 4);
                        }
                        else
                        {
                            validatedSymbol = label;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, '{label}': Labels must be shorter than 10 characters.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, '{label}': Labels may only contain letters, numbers, and underscore.");
                }
            }
            else
            {
                Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, '{label}': Labels must start with a character.");
            }

            // Symbol should be returned as caps
            return validatedSymbol.ToUpper();
        }
    }
}
