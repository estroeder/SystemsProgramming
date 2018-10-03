using System;

namespace Assignment1
{
    class ValidateValue
    {
        public int? Validate(string label, string value, int lineNumber)
        {
            int? returnValue = null;
            // Must be a signed integer value
            if (int.TryParse(value, out int validatedValue) == false)
            {
                Console.WriteLine($"Error in SYMS.dat file on line {lineNumber}, '{label}': Values must be of type signed integer ({value}).");
            }
            else
            {
                returnValue = validatedValue;
            }

            return returnValue;
        }
    }
}
