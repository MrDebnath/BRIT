namespace BRIT.DevTest.Function.Contracts
{
    public class Instruction
    {
        public Instruction(OperationEnum operation, double number)
        {
            Operation = operation;
            Number = number;
        }

        public OperationEnum Operation { get; set; }
        public double Number { get; set; } 
    }
}