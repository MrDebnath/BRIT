﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BRIT.DevTest.Function.Tests.TestData
{
    public class InstructionsTestData : IEnumerable<object[]>
    {
        private IEnumerable<object[]> ReadFile()
        {
            return File.ReadAllLines("Mapper/instructions.txt").Where(a => !string.IsNullOrEmpty(a)).Select(a => new object[] { a });
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            var items = ReadFile();
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}