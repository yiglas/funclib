using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SortedSetByShould
    {
        [Test]
        public void SortedSetBy_should_create_new_set_sorted_by_the_function()
        {
            var actual = funclib.Core.SortedSetBy(new IsGreaterThan(), 3, 5, 8, 2, 1);

            Assert.AreEqual(8, funclib.Core.First(actual));
            Assert.AreEqual(5, funclib.Core.Second(actual));
            Assert.AreEqual(1, funclib.Core.Last(actual));
        }
    }
}
