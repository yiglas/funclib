using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class IntoShould
    {
        [Test]
        public void Into_should_conjoin_values_from_into_to()
        {
            var expected = new SortedMap().Invoke(":a", 1, ":b", 2, ":c", 3);
            var actual = new Into().Invoke(new SortedMap().Invoke(), new Vector().Invoke(new Vector().Invoke(":a", 1), new Vector().Invoke(":b", 2), new Vector().Invoke(":c", 3)));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<FunctionalLibrary.Collections.SortedMap>(actual);
        }

        [Test]
        public void Into_should_split_map_into_a_vector_of_vectors()
        {
            var expected = new Vector().Invoke(new Vector().Invoke(1, 2), new Vector().Invoke(3, 4));
            var actual = new Into().Invoke(new Vector().Invoke(), new ArrayMap().Invoke(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<FunctionalLibrary.Collections.Vector>(actual);
        }

        [Test]
        public void Into_should_change_from_one_type_of_map_to_another()
        {
            var expected = new SortedMap().Invoke(":a", 1, ":b", 2, ":c", 3);
            var actual = new Into().Invoke(new SortedMap().Invoke(), new ArrayMap().Invoke(":a", 1, ":b", 2, ":c", 3));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<FunctionalLibrary.Collections.SortedMap>(actual);
        }
    }
}
