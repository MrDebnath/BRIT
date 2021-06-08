using BRIT.DevTest.Function.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Parser
{
    public interface IInstructionParser
    {
        public Task<double> Parse(InstructionSet instructionSet);
    }
}
