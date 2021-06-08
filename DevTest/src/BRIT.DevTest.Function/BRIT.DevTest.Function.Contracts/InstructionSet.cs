using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Contracts
{
    public class InstructionSet
    {
        public InstructionSet(IEnumerable<Instruction> instructions)
        {
            Instructions = instructions;
        }

        public IEnumerable<Instruction> Instructions { get; set; }
    }
}
