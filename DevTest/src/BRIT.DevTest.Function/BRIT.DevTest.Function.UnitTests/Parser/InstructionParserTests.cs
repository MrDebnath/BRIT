using BRIT.DevTest.Function.Service.Exceptions;
using BRIT.DevTest.Function.Service.Mappers;
using BRIT.DevTest.Function.Service.Parser;
using System.Threading.Tasks;
using Xunit;

namespace BRIT.DevTest.Function.UnitTests.Parser
{
    public class InstructionParserTests
    {
        private readonly IInstructionMapper _instructionMapper;
        private readonly IInstructionParser _sut;

        public InstructionParserTests()
        {
            _instructionMapper = new InstructionMapper();
            _sut = new InstructionParser();
        }

        [Theory]
        [InlineData(@"add 2
                    multiply 3
                    apply 3", 15)]
        [InlineData(@"multiply 9 
                    apply 5", 45)]
        public async Task CanParseInstructionsTest(
            string instructions,
            decimal expeted
            )
        {
            //Arrange
            var instructionSet = await _instructionMapper.Map(instructions);

            //Act
            var output = await _sut.Parse(instructionSet);

            //Assert
            Assert.Equal(expeted, output);
        }

        [Theory]
        [InlineData(@"add 2
                    apply 3
                    multiply 3",
            "Operation 'Apply' should be the last instruction")]
        [InlineData(@"multiply 9 
                    divide 0
                    apply 5",
            "Number on line '2' must be a number instead of 0")]
        public async Task CanRaiseCorrectErrorsOnInvalidInstructions(
            string instructions,
            string expectedMessage
            )
        {
            //Arrange
            var instructionSet = await _instructionMapper.Map(instructions);

            //Act
            var ex = await Assert.ThrowsAsync<InstructionFormatException>(async () => await _sut.Parse(instructionSet));

            //Assert
            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}
