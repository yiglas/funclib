using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SortedMapByShould
    {
        [Test]
        public void SortedMapBy_should_create_new_map_sorted_by_the_function()
        {
            var actual = funclib.Core.SortedMapBy(new IsGreaterThan(), 1, "a", 2, "b", 3, "c");

            Assert.AreEqual(funclib.Core.Vector(3, "c"), funclib.Core.First(actual));
            Assert.AreEqual(funclib.Core.Vector(2, "b"), funclib.Core.Second(actual));
            Assert.AreEqual(funclib.Core.Vector(1, "a"), funclib.Core.Last(actual));
        }
    }
}
