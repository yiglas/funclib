using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class FFirstShould
    {
        [Test]
        public void FFirst_should_return_null_if_empty_empty()
        {
            var actual = funclib.Core.FFirst(funclib.Core.List(funclib.Core.Vector()));

            Assert.IsNull(actual);
        }

        [Test]
        public void FFirst_should_return_the_first_items_first_item()
        {
            var expected = "a";
            var actual = funclib.Core.FFirst(funclib.Core.Vector(funclib.Core.List("a", "b", "c"), funclib.Core.List("b", "c", "d")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FFirst_should_return_first_key_when_passed_array_map()
        {
            var expected = "a";
            var actual = funclib.Core.FFirst(funclib.Core.ArrayMap("a", 1, "b", 2, "c", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
