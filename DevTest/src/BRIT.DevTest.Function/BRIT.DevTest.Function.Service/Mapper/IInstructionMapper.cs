using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Mappers
{
    public interface IInstructionMapper
    {
        Task<Contracts.InstructionSet> Map(string instructions);
    }
}
