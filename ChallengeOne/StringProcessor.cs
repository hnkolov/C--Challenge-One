using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    class StringProcessor
    {
        public static string ReadInput()
        {
            return Console.ReadLine().TrimEnd('\n');
        }

        public static int[] ExtractInput(string input)
        {
            int[] extractedInput = new int[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                extractedInput[i] = input[i] - '0';
            }
            return extractedInput;
        }

        public static string InstructionsToString(int[] instructions)
        {
            string stringOutput = "";
            foreach (int instruction in instructions)
            {
                stringOutput = stringOutput + instruction;
            }
            return stringOutput;
        }
    }
}
