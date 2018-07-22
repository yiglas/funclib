using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class UpdateInShould
    {
        [Test]
        public void UpdateIn_should_update_single_value_in_nested_strcuture()
        {
            var expected = new Vector().Invoke(hashMap(":name", "James", ":age", 26), hashMap(":name", "John", ":age", 44));
            var users = new Vector().Invoke(hashMap(":name", "James", ":age", 26), hashMap(":name", "John", ":age", 43));

            var actual = new UpdateIn().Invoke(users, new Vector().Invoke(1, ":age"), new Inc());

            Assert.AreEqual(expected, actual);
        }
    }
}
