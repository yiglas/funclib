using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IntoShould
    {
        [Test]
        public void Into_should_conjoin_values_from_into_to()
        {
            var expected = sortedMap(":a", 1, ":b", 2, ":c", 3);
            var actual = into(sortedMap(), vector(vector(":a", 1), vector(":b", 2), vector(":c", 3)));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.SortedMap>(actual);
        }

        [Test]
        public void Into_should_split_map_into_a_vector_of_vectors()
        {
            var expected = vector(vector(1, 2), vector(3, 4));
            var actual = into(vector(), arrayMap(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Into_should_change_from_one_type_of_map_to_another()
        {
            var expected = sortedMap(":a", 1, ":b", 2, ":c", 3);
            var actual = into(sortedMap(), arrayMap(":a", 1, ":b", 2, ":c", 3));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.SortedMap>(actual);
        }
    }
}
