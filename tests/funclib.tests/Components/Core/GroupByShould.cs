using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class GroupByShould
    {
        [Test]
        public void GroupBy_should_group_a_given_collection_by_the_function()
        {
            var expected = funclib.Core.HashMap(false, funclib.Core.Vector(0, 2, 4, 6, 8), true, funclib.Core.Vector(1, 3, 5, 7, 9));
            var actual = funclib.Core.GroupBy(new IsOdd(), funclib.Core.Range(10));

            Assert.AreEqual(expected, actual);
        }
    }
}
