using BRIT.DevTest.Function.Service.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using BRIT.DevTest.Function.Tests.TestData;

namespace BRIT.DevTest.Function.Tests.Mapper
{
    public class InstructionMapperTests
    {
        private readonly IInstructionMapper _sut;

        public InstructionMapperTests()
        {
            _sut = new InstructionMapper();
        }

        [Theory]
        [ClassData(typeof(InstructionsTestData))]
        public void CanMapInstructions(
            string instructions
            )
        {
            //Arrange
            var lineCount = instructions.Split(Environment.NewLine).Count();

            //Act
            var actual = _sut.Map(instructions).Result;

            //Assert
            Assert.AreEqual(lineCount, actual.Instructions.Count());
        }
    }
}
