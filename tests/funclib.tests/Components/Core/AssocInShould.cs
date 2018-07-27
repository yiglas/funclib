using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class AssocInShould
    {
        [Test]
        public void AssocIn_should_update_item_in_vector()
        {
            var expected = vector(hashMap("Name", "James", "Age", 26), hashMap("Name", "John", "Age", 44));
            var map = vector(hashMap("Name", "James", "Age", 26), hashMap("Name", "John", "Age", 26));
            var actual = assocIn(map, vector(1, "Age"), 44);

            Assert.AreEqual(expected, actual);
        }
    }
}
