using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class ExpressionProcessor
    {
        public void Process(List<string> expressions)
        {
            foreach(string expression in expressions)
            {
                ParseEquation(expression);
            }
        }

        private void ParseEquation(string expression)
        {
            List<string> operands = new List<string>(expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries));

            if (operands.Count < 3)
            {
                foreach(string operand in operands)
                {
                    // Validate each operand individually
                    Validate(operand);
                }

                // todo: Determine how to evaluate the equation if it exists
            }
            else
            {
                Console.WriteLine($"Error - Maximum of two values/operands per expression ({expression})");
            }
        }

        private void Validate(string expression)
        {
            ValidateDirectAddressing directValidator = new ValidateDirectAddressing();
            ValidateImmediateAddressing immediateValidator = new ValidateImmediateAddressing();
            ValidateIndexedAddressing indexedValidator = new ValidateIndexedAddressing();
            ValidateIndirectAddressing indirectValidator = new ValidateIndirectAddressing();

            if(expression.Contains(',')) // Indexed Addressing
            {
                indexedValidator.Validate(expression);
            }
            else if(expression[0] == '@') // Indirect Addressing
            {
                indirectValidator.Validate(expression);
            }
            else if(expression[0] == '#' || int.TryParse(expression, out int n)) // Immediate Addressing
            {
                immediateValidator.Validate(expression);
            }
            else // Direct Addressing
            {
                directValidator.Validate(expression);
            }
        }
    }
}