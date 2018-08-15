using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SortShould
    {
        [Test]
        public void Sort_should_sort_ascending()
        {
            var expected = funclib.Core.List(1, 2, 3, 4);
            var actual = funclib.Core.Sort(funclib.Core.Vector(3, 1, 2, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_should_sort_using_a_function()
        {
            var expected = funclib.Core.List(10, 5, 2);
            var actual = funclib.Core.Sort(new IsGreaterThan(), funclib.Core.Values(funclib.Core.ArrayMap(":foo", 5, ":bar", 2, ":baz", 10)));

            Assert.AreEqual(expected, actual);
        }
    }
}
