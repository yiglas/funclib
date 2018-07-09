using FunctionalLibrary.Collections;
using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class FindShould
    {
        [Test]
        public void Find_should_return_KeyValuePair_if_found()
        {
            var expected = new KeyValuePair(":a", 1);
            var actual = new Find().Invoke(new FunctionalLibrary.Core.HashMap().Invoke(":a", 1, ":b", 2, ":c", 3), ":a");

            Assert.IsInstanceOf<KeyValuePair>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Find_should_return_null_when_key_doesnot_exist()
        {
            var actual = new Find().Invoke(new FunctionalLibrary.Core.HashMap().Invoke(":a", 1, ":b", 2, ":c", 3), ":d");

            Assert.IsNull(actual);
        }

        [Test]
        public void Find_should_return_KeyValuePair_where_key_is_index_value_is_item_in_vector()
        {
            var expected = new KeyValuePair(2, ":c");
            var actual = new Find().Invoke(new FunctionalLibrary.Core.Vector().Invoke(":a", ":b", ":c"), 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
