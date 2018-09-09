using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clifford
{
    public class Engine
    {
        /// <summary>
        /// Clifford Engine entry point
        /// </summary>
        /// <param name="args">Unused</param>
        static void Main(string[] args)
        {
            CliffordProgramCodeCollection codes = new CliffordProgramCodeCollection();
            CliffordInstructionQueue instructions = new CliffordInstructionQueue();
            CliffordStack stack = new CliffordStack();

            // Get codes as a whitespace-separated string
            string input = Console.ReadLine();

            // Tokenise on whitespace
            string[] commandsString = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string command in commandsString)
            {
                if (!codes.Add(command))
                    Console.WriteLine("Warning. Failed to parse command: " + command);
            }

            // Generate Instructions
            instructions = codes.GenerateInstructions();
            if (instructions == null)
            {
                Console.WriteLine("Error generating instructions. Check input.");
                return;
            }

            // Execute Instructions
            while (!instructions.IsEmpty())
            {
#if DEBUG
                DisplayEngineState(stack, instructions);
#endif
                CliffordInstruction instruction = instructions.FetchInstruction();

                if (instruction != null)
                    stack.ExecuteInstruction(instruction);
            }

            // Display resultant stack
            DisplayEngineState(stack);

            // Stay alive!
            Console.ReadLine();
        }

        /// <summary>
        /// Displays the current state of the Clifford Engine
        /// </summary>
        /// <param name="stack">Stack reference</param>
        /// <param name="instructions">Remaining instructions reference</param>
        private static void DisplayEngineState(CliffordStack stack, CliffordInstructionQueue instructions = null)
        {
            Console.WriteLine(stack.ToString());

            if (instructions != null)
                Console.WriteLine(instructions.ToString());
        }
    }
}
