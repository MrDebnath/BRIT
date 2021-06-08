using BRIT.DevTest.Function.Contracts;
using BRIT.DevTest.Function.Service.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Mappers
{
    public class InstructionMapper : IInstructionMapper
    {
        private const string Separator = " ";
        private readonly string _LineSeparator = Environment.NewLine;

        public async Task<Contracts.InstructionSet> Map(string instructions) =>
            new InstructionSet(instructions.Trim('\r', '\n').Split(_LineSeparator).Select(line =>
            {
                var parts = line.Trim(' ').Split(Separator);
                InstructionValidator.LineValidator(line, parts, out var operation, out var number);
                return new Instruction(operation, number);
            }));
    }
}
