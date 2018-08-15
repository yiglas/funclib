using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class LastShould
    {
        [Test]
        public void Last_should_return_last_item_for_a_vector()
        {
            var expected = 5;
            var actual = funclib.Core.Last(funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Last_should_return_last_KeyValuePair_for_a_map()
        {
            var expected = new funclib.Collections.KeyValuePair(":three", 3);
            var actual = funclib.Core.Last(funclib.Core.ArrayMap(":one", 1, ":two", 2, ":three", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
