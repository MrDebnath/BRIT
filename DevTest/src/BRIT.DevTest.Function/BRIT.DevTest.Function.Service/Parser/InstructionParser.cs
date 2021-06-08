using BRIT.DevTest.Function.Contracts;
using BRIT.DevTest.Function.Service.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BRIT.DevTest.Function.Service.Parser
{
    public class InstructionParser : IInstructionParser
    {
        public async Task<double> Parse(InstructionSet instructionSet)
        {
            var instructions = instructionSet.Instructions.ToList();
            var output = instructions.First().Number;

            for (int i = 0; i < instructions.Count(); i++)
            {
                var operation = instructions[i].Operation;

                //Last operation
                var isLast = i == (instructions.Count - 1);
                if ((isLast && operation != OperationEnum.Apply) ||
                    (!isLast && operation == OperationEnum.Apply))
                {
                    throw new InstructionFormatException($"Operation '{OperationEnum.Apply}' should be the last instruction");
                }
                else if(operation == OperationEnum.Apply)
                {
                    //EOF reached
                    continue;
                }

                var operand = instructions[i + 1].Number;

                switch (operation)
                {
                    case OperationEnum.Add:
                        output += operand;
                        break;
                    case OperationEnum.Divide:
                        {
                            if (output == 0)
                            {
                                throw new InstructionFormatException($"Number on line '{i + 1}' must be a number instead of 0");
                            }

                            output = operand / output;
                            break;
                        }
                    case OperationEnum.Multiply:
                        output *= operand;
                        break;
                    case OperationEnum.Substract:
                        output = operand - output;
                        break;
                    default:
                        throw new InstructionFormatException($"Instruction operation '{instructions[i].Operation}' is not supported");
                }
            }

            return output;
        }
    }
}
