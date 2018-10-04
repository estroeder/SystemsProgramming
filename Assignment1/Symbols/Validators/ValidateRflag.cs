using System;

namespace Assignment1
{
    class ValidateRflag
    {
        public bool? Validate(string symbol, string rflag, int lineNumber)
        {
            bool? validatedRflag = null;

            if (rflag == "0" || rflag.ToUpper() == "F" || rflag.ToUpper() == "FALSE")
            {
                validatedRflag = false;
            }
            else if (rflag == "1" || rflag.ToUpper() == "T" || rflag.ToUpper() == "TRUE")
            {
                validatedRflag = true;
            }
            else
            {
                Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, '{symbol}': Rflag must be a boolean format ({rflag}).");
            }

            return validatedRflag;
        }
    }
}