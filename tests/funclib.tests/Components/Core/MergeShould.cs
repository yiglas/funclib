using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class MergeShould
    {
        [Test]
        public void Merge_should_return_new_map_with_maps_conjed()
        {
            var expected = funclib.Core.HashMap(":a", 1, ":c", 3, ":b", 9, ":d", 4);
            var actual = funclib.Core.Merge(funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3), funclib.Core.ArrayMap(":b", 9, ":d", 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Merge_should_allow_null_as_the_second_argument()
        {
            var expected = funclib.Core.HashMap(":a", 1);
            var actual = funclib.Core.Merge(funclib.Core.ArrayMap(":a", 1), null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Merge_should_allow_null_as_the_first_argument()
        {
            var expected = funclib.Core.HashMap(":a", 1);
            var actual = funclib.Core.Merge(null, funclib.Core.ArrayMap(":a", 1));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Merge_should_return_null_if_passed_null()
        {
            Assert.IsNull(funclib.Core.Merge(null, null));
        }
    }
}
