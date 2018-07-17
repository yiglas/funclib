using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class AssocInShould
    {
        [Test]
        public void AssocIn_should_update_item_in_vector()
        {
            var expected = new Vector().Invoke(new HashMap().Invoke("Name", "James", "Age", 26), new HashMap().Invoke("Name", "John", "Age", 44));
            var map = new Vector().Invoke(new HashMap().Invoke("Name", "James", "Age", 26), new HashMap().Invoke("Name", "John", "Age", 26));
            var actual = new AssocIn().Invoke(map, new Vector().Invoke(1, "Age"), 44);

            Assert.AreEqual(expected, actual);
        }
    }
}
