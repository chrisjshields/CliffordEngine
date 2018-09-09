using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clifford
{
    /// <summary>
    /// The actual Clifford Stack. Inherits from System.Collections.Generic.Stack.
    /// </summary>
    public class CliffordStack : Stack<int>
    {
        /// <summary>
        /// Perform an instruction (a command and an optional parameter) on the stack
        /// </summary>
        /// <param name="instruction">The instruction to execute</param>
        public void ExecuteInstruction(CliffordInstruction instruction)
        {
            switch (instruction.Command)
            {
                case Command.Push:
                    {
                        if (!instruction.Parameter.HasValue)
                            throw new InvalidOperationException();
                        Push((int)instruction.Parameter);
                        break;
                    }
                case Command.Pop:
                    {
                        Pop();
                        break;
                    }
                case Command.Add:
                    {
                        int[] operands = GetOperands(2);
                        Push(operands[0] + operands[1]);
                        break;
                    }
                case Command.Subtract:
                    {
                        int[] operands = GetOperands(2);
                        Push(operands[0] - operands[1]);
                        break;
                    }
                case Command.Multiply:
                    {
                        int[] operands = GetOperands(2);
                        Push(operands[0] * operands[1]);
                        break;
                    }
                case Command.Divide:
                    {
                        int[] operands = GetOperands(2);
                        Push(operands[0] / operands[1]);
                        break;
                    }
                default: throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Generates a textual representation of the stack, displaying the contents in decimal and hex
        /// </summary>
        /// <returns>A string that represents the stack (seperated by newlines)</returns>
        public override string ToString()
        {
            string output = "Dec\tHex" + Environment.NewLine;
            foreach (int number in this)
            {
                output += number.ToString("D") + "\t" + number.ToString("X") + Environment.NewLine;
            }
            return output;
        }

        /// <summary>
        /// Retrieves [count] operands from the stack and returns them in the order they were originally put onto the stack
        /// </summary>
        /// <param name="count">Number of operands to retreive from stack</param>
        /// <returns>Integer array of operands</returns>
        private int[] GetOperands(int count)
        {
            int[] operands = new int[count];

            while (count-- > 0)
                operands[count] = Pop();

            return operands;
        }
    }
}
