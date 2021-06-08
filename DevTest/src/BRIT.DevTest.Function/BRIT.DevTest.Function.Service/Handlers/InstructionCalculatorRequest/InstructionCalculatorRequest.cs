using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Handlers.InstructionCalculatorRequest
{
    public class InstructionCalculatorRequest : IRequest<InstructionCalculatorResponse>
    {
        public InstructionCalculatorRequest(string instructions)
        {
            Instructions = instructions;
        }

        public string Instructions { get; set; }
    }
}
