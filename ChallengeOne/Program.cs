using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChallengeOne
{
    class Program
    {
        private const int NumberOfInstructions = 5;
        int Mod(int dividend, int divisor)
        {
            return (dividend + divisor) % divisor;
        }
        string ReadInput()
        {
            return Console.ReadLine().TrimEnd('\n');
        }

        void ExtractInput(string input, int[] output)
        {
            for (var i = 0; i < input.Length; i++)
                output[i] = input[i] - '0';
        }

        void DoOneStep(int[] output, ref int currentIndex, ref int direction)
        {
            int instruction = output[currentIndex];
            int previousInstruction = Mod((currentIndex - direction),output.Length);
            switch (instruction)
            {
                case 1:
                    break;

                case 2:
                    output[previousInstruction] = Mod(output[previousInstruction] + 1, NumberOfInstructions);
                    break;

                case 3:
                    output[previousInstruction] = Mod(output[previousInstruction] - 1, NumberOfInstructions);
                    break;

                case 4:
                    direction = -direction;
                    break;
            }
            currentIndex = Mod(currentIndex + direction, output.Length);
        }

        string FinalOutput(string input)
        {
            int[] output = new int[input.Length];
            int numberOfIterations = 0;
            string stringOutput="";
            ExtractInput(input,output);
            int currentIndex = 0;
            int direction = 1;
            while (output[currentIndex] != 0)
            {
                DoOneStep(output, ref currentIndex, ref direction);
                foreach (int o in output)
                    Console.Write(o);
                Console.WriteLine();
                numberOfIterations++;
            }
            foreach (int outputValue in output)
            {
                stringOutput = stringOutput + outputValue;
            }
            Console.WriteLine("{0} iterations",numberOfIterations);
            return stringOutput;
        }

        void Run()
        {
            string input;
            input = ReadInput();
            Console.WriteLine(FinalOutput(input));
        }

        bool Test()
        {
            return FinalOutput("121") == "203";
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
            Console.ReadKey();
        }
    }
}
