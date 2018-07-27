using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class ArrayMapShould
    {
        [Test]
        public void ArrayMap_should_return_empty_map_when_no_parameters_passed()
        {
            var expected = 0;
            var actual = arrayMap();

            Assert.AreEqual(expected, count(actual));
        }
    }
}
