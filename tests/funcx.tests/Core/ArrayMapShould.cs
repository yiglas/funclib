using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ArrayMapShould
    {
        [Test]
        public void ArrayMap_should_return_empty_map_when_no_parameters_passed()
        {
            var expected = 0;
            var actual = new ArrayMap().Invoke();

            Assert.AreEqual(expected, new Count().Invoke(actual));
        }
    }
}
