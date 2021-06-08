using System;
using System.Collections.Generic;
using System.Text;

namespace BRIT.DevTest.Function.Service.Exceptions
{
    public class InstructionFormatException : Exception
    {
        public InstructionFormatException(string? message) : base(message)
        {
        }
    }
}
