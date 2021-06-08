using BRIT.DevTest.Function.Service.Mappers;
using System;
using System.Linq;
using Xunit;
using System.Threading.Tasks;
using BRIT.DevTest.Function.Service.Exceptions;

namespace BRIT.DevTest.Function.UnitTests.Mapper
{
    public class InstructionMapperTests
    {
        private readonly IInstructionMapper _sut;

        public InstructionMapperTests()
        {
            _sut = new InstructionMapper();
        }

        [Theory]
        [InlineData(@"add 2
                    multiply 3
                    apply 3")]
        [InlineData(@"multiply 9 
                    apply 5")]
        public async Task CanMapInstructions(
            string instructions)
        {
            //Arrange
            var expected = instructions.Trim('\r', '\n').Split(Environment.NewLine).Count();

            //Act
            var actual = await _sut.Map(instructions);

            //Assert
            Assert.Equal(expected, actual.Instructions.Count());
        }

        [Theory]
        [InlineData(@"add 2 XXX
                    apply 3",
        "Instructions in each line must be formatted as 'operation' 'number' e.g. 'add 1' instead of 'add 2 XXX'")]
        [InlineData(@"XXXX 9
                    apply 5",
        "Instruction operation must be one of [Add, Divide, Multiply, Substract, Apply] instead of 'XXXX'")]
        [InlineData(@"multiply 9XXXX
                    apply 5",
        "Instruction operand must be a number instead of '9XXXX'")]
        public async Task CanRaiseCorrectErrorsOnInvalidInstructions(
            string instructions,
            string expectedMessage)
        {
            //Act
            var ex = await Assert.ThrowsAsync<InstructionFormatException>(async () => (await _sut.Map(instructions)).Instructions.Count());

            //Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
