using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class SelectKeysShould
    {
        [Test]
        public void SelectKeys_should_pull_keys_that_exists_from_a_map()
        {
            var expected = arrayMap(":a", 1);
            var actual = selectKeys(arrayMap(":a", 1, ":b", 2), vector(":a"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SelectKeys_should_pull_those_keys_that_exists_from_a_map()
        {
            var expected = arrayMap(":a", 1);
            var actual = selectKeys(arrayMap(":a", 1, ":b", 2), vector(":a", ":c"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SelectedKeys_should_return_a_hashmap()
        {
            var actual = selectKeys(arrayMap(":a", 1, ":b", 2), vector(":a", ":c"));

            Assert.IsInstanceOf<funclib.Collections.HashMap>(actual);
        }

        [Test]
        public void SelectedKeys_should_work_with_passing_vectors_as_well()
        {
            var expected = arrayMap(0, 1, 2, 3);
            var actual = selectKeys(vector(1, 2, 3), vector(0, 0, 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
