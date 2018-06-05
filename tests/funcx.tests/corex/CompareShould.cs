using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class CompareShould
    {
        [Test]
        public void Compare_should_return_zero_when_testing_two_list_with_same_values()
        {
            var actual = compare(new List<int>() { 0, 1, 2 }, new List<int>() { 0, 1, 2 });

            Assert.AreEqual(0, actual);
        }
    }
}
