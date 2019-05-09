using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SortByShould
    {
        [Test]
        public void SortBy_should_sort_vector_by_comparer()
        {
            var expected = funclib.Core.List("c", "bb", "aaa");
            var actual = funclib.Core.SortBy(new Count(), funclib.Core.Vector("aaa", "c", "bb"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBy_should_sort_by_keyfn_and_comparer()
        {
            var expected = funclib.Core.List(funclib.Core.Vector(2, 3), funclib.Core.Vector(2, 2), funclib.Core.Vector(1, 2));
            var actual = funclib.Core.SortBy(new First(), new IsGreaterThan(), funclib.Core.Vector(funclib.Core.Vector(1, 2), funclib.Core.Vector(2, 2), funclib.Core.Vector(2, 3)));

            Assert.AreEqual(expected, actual);
        }
    }
}
