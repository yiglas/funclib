using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class RangeShould
    {
        [Test]
        public void Range_should_step_when_supplied()
        {
            var expected = list(0, 2, 4, 6);
            var actual = range(0, 7, 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
