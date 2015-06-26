using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    class InstructionProcessor
    {

        private const int NumberOfInstructions = 5;

        int Mod(int dividend, int divisor)
        {
            return (dividend + divisor) % divisor;
        }

        bool IsFinished(int[] instructions, int currentIndex)
        {
            return instructions[currentIndex] == 0;
        }

        void DoOneStep(int[] instructions, ref int currentIndex, ref int direction)
        {
            int instruction = instructions[currentIndex];
            int previousInstruction = Mod((currentIndex - direction), instructions.Length);
            switch (instruction)
            {
                case 1:
                    break;

                case 2:
                    instructions[previousInstruction] = Mod(instructions[previousInstruction] + 1, NumberOfInstructions);
                    break;

                case 3:
                    instructions[previousInstruction] = Mod(instructions[previousInstruction] - 1, NumberOfInstructions);
                    break;

                case 4:
                    direction = -direction;
                    break;
            }
            currentIndex = Mod(currentIndex + direction, instructions.Length);
        }

        string DetermineOutput(string input)
        {
            int[] sequence = new int[input.Length];
            string stringOutput = "";
            sequence = StringProcessor.ExtractInput(input);
            int currentIndex = 0;
            int direction = 1;
            while (!IsFinished(sequence,currentIndex))
            {
                DoOneStep(sequence, ref currentIndex, ref direction);
            }
            stringOutput = StringProcessor.InstructionsToString(sequence);
            return stringOutput;
        }

        public void Run()
        {
            string input;
            input = StringProcessor.ReadInput();
            Console.WriteLine(DetermineOutput(input));
        }

        bool Test()
        {
            return DetermineOutput("121") == "203";
        }
    }
}
