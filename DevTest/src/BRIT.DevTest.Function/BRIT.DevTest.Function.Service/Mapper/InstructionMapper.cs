using BRIT.DevTest.Function.Contracts;
using BRIT.DevTest.Function.Service.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Mappers
{
    public class InstructionMapper : IInstructionMapper
    {
        private const string Separator = " ";
        private readonly string _LineSeparator = Environment.NewLine;

        public async Task<Contracts.InstructionSet> Map(string instructions)
        {
            var instructionSet = new InstructionSet()
            {
                Instructions = instructions.Split(_LineSeparator).Select(line =>
                {
                    var parts = line.Split(Separator);

                    if (!(parts.Count() == 2))
                    {
                        throw new InstructionFormatException($"Instructions in each line must be formatted as 'operation' 'number' e.g. 'add 1' instead of '{line}'");
                    }


                    if (!Enum.TryParse<OperationEnum>(parts[0], true, out var operation))
                    {
                        throw new InstructionFormatException($"Instruction operation must be one of [{string.Join(", ", Enum.GetNames(typeof(OperationEnum)))}] instead of '{parts[0]}'");
                    }


                    if (!decimal.TryParse(parts[1], out var number))
                    {
                        throw new InstructionFormatException($"Instruction operand must be a number instead of '{parts[1]}'");
                    }

                    var instruction = new Instruction()
                    {
                        Operation = operation,
                        Number = number
                    };

                    return instruction;
                })
            };

            return instructionSet;
        }
    }
}
