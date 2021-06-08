namespace BRIT.DevTest.Function.Contracts
{
    public class Instruction
    {
        public Instruction(OperationEnum operation, decimal number)
        {
            Operation = operation;
            Number = number;
        }

        public OperationEnum Operation { get; set; }
        public decimal Number { get; set; } 
    }
}