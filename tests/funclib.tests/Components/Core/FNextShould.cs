using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class FNextShould
    {
        [Test]
        public void FNext_should_return_null_with_no_items()
        {
            Assert.IsNull(funclib.Core.FNext(funclib.Core.Vector()));
        }

        [Test]
        public void FNext_should_return_null_with_only_one_item()
        {
            Assert.IsNull(funclib.Core.FNext(funclib.Core.Vector(1)));
        }

        [Test]
        public void FNext_should_return_first_item_of_the_next_list()
        {
            var expected = funclib.Core.Vector("b", "a", "c");
            var actual = funclib.Core.FNext(funclib.Core.List(funclib.Core.Vector("a", "b", "c"), funclib.Core.Vector("b", "a", "c")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FNext_should_return_first_KeyValuePair_when_passed_array_map()
        {
            var expected = new funclib.Collections.KeyValuePair("b", 2);
            var actual = funclib.Core.FNext(funclib.Core.ArrayMap("a", 1, "b", 2, "c", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
