using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clifford
{
    /// <summary>
    /// Collection of Clifford Engine program codes (integers). These are the raw values that are entered as a whitespace-separated string.
    /// </summary>
    public class CliffordProgramCodeCollection
    {
        List<int> codes = new List<int>();

        /// <summary>
        /// Add a new code (parse from int)
        /// </summary>
        /// <param name="command">The code as a string</param>
        /// <returns>Boolean true on success</returns>
        public bool Add(string code)
        {
            int i;
            if (int.TryParse(code, out i))
            {
                codes.Add(i);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generates a collection of CliffordInstructions 
        /// </summary>
        /// <returns>CliffordInstructionCollection or null (failure)</returns>
        public CliffordInstructionQueue GenerateInstructions()
        {
            CliffordInstructionQueue instructions = new CliffordInstructionQueue();

            // Loop over codes, checking the next code for a parameter if required
            for (int c = 0; c < codes.Count; c++)
            {
                int? parameter = null;
                Command command = (Command)codes[c];

                if (command == Command.Push) // Arguments == 1
                {
                    if (c + 1 < codes.Count)
                        parameter = codes[++c]; // Use next code as the parameter
                    else
                        return null; // Fail - required parameter is missing
                }

                instructions.AddInstruction(new CliffordInstruction(command, parameter));
            }

            return instructions;
        }
    }
}
