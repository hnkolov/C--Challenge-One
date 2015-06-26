using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    class InstructionProcessor
    {
        private int[] sequence;
        private int currentIndex, direction;
        private const int NumberOfInstructions = 5;
        private Action[] steps;

        private int Mod(int dividend, int divisor)
        {
            return (dividend + divisor) % divisor;
        }

        private bool IsFinished()
        {
            return sequence[currentIndex] == 0;
        }

        private void Move()
        {
            currentIndex = Mod(currentIndex + direction, sequence.Length);
        }

        private void DoNothing()
        {
            
        }

        private void IncrementPrevious()
        {
            int previousInstruction = Mod((currentIndex - direction), sequence.Length);
            sequence[previousInstruction] = Mod(sequence[previousInstruction] + 1, NumberOfInstructions);
        }

        private void DecrementPrevious()
        {
            int previousInstruction = Mod((currentIndex - direction), sequence.Length);
            sequence[previousInstruction] = Mod(sequence[previousInstruction] - 1, NumberOfInstructions);
        }

        private void ReverseDirection()
        {
            direction = -direction;
        }

        private void DoOneStep()
        {
            int instruction = sequence[currentIndex];

            steps[instruction]();
            Move();
        }

        private string DetermineOutput(string input)
        {
            string stringOutput;
            sequence = new int[input.Length];
            sequence = StringProcessor.ExtractInput(input);
            currentIndex = 0;
            direction = 1;
            steps = new Action[] { null, DoNothing, IncrementPrevious, DecrementPrevious, ReverseDirection };
            while (!IsFinished())
            {
                DoOneStep();
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
    }
}
