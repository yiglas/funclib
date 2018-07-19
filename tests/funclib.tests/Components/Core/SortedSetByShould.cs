using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;


namespace funclib.Tests.Components.Core
{
    public class SortedSetByShould
    {
        [Test]
        public void SortedSetBy_should_create_new_set_sorted_by_the_function()
        {
            var actual = new SortedSetBy().Invoke(new IsGreaterThan(), 3, 5, 8, 2, 1);

            Assert.AreEqual(8, new First().Invoke(actual));
            Assert.AreEqual(5, new Second().Invoke(actual));
            Assert.AreEqual(1, new Last().Invoke(actual));
        }
    }
}
