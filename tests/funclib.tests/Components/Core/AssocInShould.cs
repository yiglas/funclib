using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class AssocInShould
    {
        [Test]
        public void AssocIn_should_update_item_in_vector()
        {
            var expected = new Vector().Invoke(hashMap("Name", "James", "Age", 26), hashMap("Name", "John", "Age", 44));
            var map = new Vector().Invoke(hashMap("Name", "James", "Age", 26), hashMap("Name", "John", "Age", 26));
            var actual = assocIn(map, new Vector().Invoke(1, "Age"), 44);

            Assert.AreEqual(expected, actual);
        }
    }
}
