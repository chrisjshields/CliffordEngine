using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clifford
{
    /// <summary>
    public enum Command
    {
        Push,       // (takes 1 argument)   Pushes its argument onto the Clifford stack.
        Pop,        // (takes no arguments) Discards the number at the top of the Clifford stack.
        Add,        // (takes no arguments) Removes the top two numbers from the stack, adds them and then pushes the total back onto the stack.
        Subtract,   // (takes no arguments) Removes the top two numbers from the stack, subtracts them and then pushes the total back onto the stack.
        Multiply,   // (takes no arguments) Removes the top two numbers from the stack, multiplies them and then pushes the total back onto the stack.
        Divide      // (takes no arguments) Removes the top two numbers from the stack, divies them and then pushes the result back onto the stack.
    }

    /// <summary>
    /// Command and optional parameter
    /// </summary>
    public class CliffordInstruction
    {
        private Command command;
        private int? parameter;

        public Command Command
        {
            get { return command; }
            set { command = value; }
        }

        public int? Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        public CliffordInstruction(Command command, int? parameter)
        {
            this.command = command;
            this.parameter = parameter;
        }
    }

    /// <summary>
    /// Queue (FIFO) of Clifford Instructions
    /// </summary>
    public class CliffordInstructionQueue
    {
        Queue<CliffordInstruction> instructions = new Queue<CliffordInstruction>();

        /// <summary>
        /// Adds a new instruction to the instruction queue
        /// </summary>
        /// <param name="instruction">The instruction to add</param>
        public void AddInstruction(CliffordInstruction instruction)
        {
            instructions.Enqueue(instruction);
        }

        /// <summary>
        /// Fetches an instruction from the queue
        /// </summary>
        /// <returns>The oldest CliffordInstruction in the queue</returns>
        public CliffordInstruction FetchInstruction()
        {
            if (instructions.Count > 0)
                return instructions.Dequeue();
            else
                return null;
        }

        /// <summary>
        /// Generates a textual representation of the instruction collection
        /// </summary>
        /// <returns>A string that represents the instruction collection</returns>
        public override string ToString()
        {
            string output = string.Empty;
            foreach (CliffordInstruction instruction in instructions)
            {
                output += "<< " + instruction.Command + " ";
                if (instruction.Parameter.HasValue)
                    output += instruction.Parameter + " ";
            }
            output += Environment.NewLine;
            return output;
        }

        /// <summary>
        /// Checks if the instruction collection is empty
        /// </summary>
        /// <returns>Boolean true on empty</returns>
        public bool IsEmpty()
        {
            if (instructions.Count == 0)
                return true;
            else
                return false;
        }
    }
}
