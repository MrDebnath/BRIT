using System.Runtime.Serialization;

namespace BRIT.DevTest.Function.Contracts
{
    public enum OperationEnum
    {
        [EnumMember(Value = "add")]
        Add,

        [EnumMember(Value = "divide")]
        Divide,
        
        [EnumMember(Value = "multiply")]
        Multiply,
        
        [EnumMember(Value = "substract")]
        Substract,
        
        [EnumMember(Value = "apply")]
        Apply
    }
}