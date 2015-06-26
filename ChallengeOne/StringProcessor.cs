using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    class StringProcessor
    {
        public static bool IsDigit(char character)
        {
            return character >= '0' && character <= '9';
        }
        public static string ReadInput()
        {
            return Console.ReadLine().TrimEnd('\n');
        }

        public static int[] ExtractInput(string input)
        {
            int[] extractedInput = new int[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                if (!IsDigit(input[i]))
                    throw new Exception("Not a number.");
                extractedInput[i] = Convert.ToInt32(input[i]);
            }
            return extractedInput;
        }

        public static string InstructionsToString(int[] sequence)
        {
            string stringOutput = "";
            foreach (int instruction in sequence)
            {
                stringOutput = stringOutput + instruction;
            }
            return stringOutput;
        }
    }
}
