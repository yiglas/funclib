using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IterateShould
    {
        [Test]
        public void Iterate_should_allow_an_IFunctionParams_to_be_passed()
        {
            var plus_one = func((object[] more) => inc(first(more)));
            var expected = list(5, 6, 7, 8, 9);
            var actual = take(5, iterate(plus_one, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
