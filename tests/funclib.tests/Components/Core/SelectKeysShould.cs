using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SelectKeysShould
    {
        [Test]
        public void SelectKeys_should_pull_keys_that_exists_from_a_map()
        {
            var expected = funclib.Core.ArrayMap(":a", 1);
            var actual = funclib.Core.SelectKeys(funclib.Core.ArrayMap(":a", 1, ":b", 2), funclib.Core.Vector(":a"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SelectKeys_should_pull_those_keys_that_exists_from_a_map()
        {
            var expected = funclib.Core.ArrayMap(":a", 1);
            var actual = funclib.Core.SelectKeys(funclib.Core.ArrayMap(":a", 1, ":b", 2), funclib.Core.Vector(":a", ":c"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SelectedKeys_should_return_a_hashmap()
        {
            var actual = funclib.Core.SelectKeys(funclib.Core.ArrayMap(":a", 1, ":b", 2), funclib.Core.Vector(":a", ":c"));

            Assert.IsInstanceOf<funclib.Collections.HashMap>(actual);
        }

        [Test]
        public void SelectedKeys_should_work_with_passing_vectors_as_well()
        {
            var expected = funclib.Core.ArrayMap(0, 1, 2, 3);
            var actual = funclib.Core.SelectKeys(funclib.Core.Vector(1, 2, 3), funclib.Core.Vector(0, 0, 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
