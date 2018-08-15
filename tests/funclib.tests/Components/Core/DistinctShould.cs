using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DistinctShould
    {
        [Test]
        public void Distinct_should_return_lazy_list_of_distinct_values()
        {
            var expected = funclib.Core.List(1, 2, 3, 4, 5);
            var actual = funclib.Core.Distinct(funclib.Core.Vector(1, 2, 1, 3, 1, 4, 1, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
