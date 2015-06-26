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
        static void Main(string[] args)
        {
            InstructionProcessor instructionProcessor = new InstructionProcessor();
            instructionProcessor.Run();
            Console.ReadKey();
        }
    }
}
