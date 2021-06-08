using BRIT.DevTest.Function.Service.Mappers;
using BRIT.DevTest.Function.Service.Parser;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Handlers.InstructionCalculatorRequest
{
    public class InstructionCalculatorRequestHandler : IRequestHandler<InstructionCalculatorRequest, InstructionCalculatorResponse>
    {
        public InstructionCalculatorRequestHandler(IInstructionMapper instructionSetMapper, IInstructionParser instructionParser)
        {
            InstructionSetMapper = instructionSetMapper;
            InstructionParser = instructionParser;
        }

        IInstructionMapper InstructionSetMapper { get; }
        IInstructionParser InstructionParser { get; }

        public async Task<InstructionCalculatorResponse> Handle(InstructionCalculatorRequest request, CancellationToken cancellationToken)
        {
            var instructionSet = await InstructionSetMapper.Map(request.Instructions);

            var output = await InstructionParser.Parse(instructionSet);

            return new InstructionCalculatorResponse() {
                Output = output
            };
        }
    }
}
