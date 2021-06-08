using BRIT.DevTest.Function.Service.Mappers;
using BRIT.DevTest.Function.Service.Parser;
using BRIT.DevTest.Function.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace BRIT.DevTest.Function.Tests.Parser
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
        [ClassData(typeof(InstructionsTestData))]
        public void CanParseInstructionsTest(
            string instructions
            )
        {
            //Arrange
            var instructionSet = _instructionMapper.Map(instructions).Result;

            //Act
            var output = _sut.Parse(instructionSet);

            //Assert
            Assert.Equals(output, 15);
        }
    }
}
