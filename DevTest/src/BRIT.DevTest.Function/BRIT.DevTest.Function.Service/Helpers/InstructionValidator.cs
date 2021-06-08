using BRIT.DevTest.Function.Contracts;
using BRIT.DevTest.Function.Service.Exceptions;
using System;
using System.Linq;

namespace BRIT.DevTest.Function.Service.Helpers
{
    public static class InstructionValidator
    {
        public static void LineValidator(string line, string[] parts, out OperationEnum operation, out decimal number)
        {
            if (!(parts.Count() == 2))
            {
                throw new InstructionFormatException($"Instructions in each line must be formatted as 'operation' 'number' e.g. 'add 1' instead of '{line}'");
            }

            if (!Enum.TryParse<OperationEnum>(parts[0], true, out operation))
            {
                throw new InstructionFormatException($"Instruction operation must be one of [{string.Join(", ", Enum.GetNames(typeof(OperationEnum)))}] instead of '{parts[0]}'");
            }

            if (!decimal.TryParse(parts[1], out number))
            {
                throw new InstructionFormatException($"Instruction operand must be a number instead of '{parts[1]}'");
            }
        }
    }
}
