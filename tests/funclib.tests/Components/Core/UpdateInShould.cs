using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class UpdateInShould
    {
        [Test]
        public void UpdateIn_should_update_single_value_in_nested_strcuture()
        {
            var expected = vector(hashMap(":name", "James", ":age", 26), hashMap(":name", "John", ":age", 44));
            var users = vector(hashMap(":name", "James", ":age", 26), hashMap(":name", "John", ":age", 43));

            var actual = updateIn(users, vector(1, ":age"), new Inc());

            Assert.AreEqual(expected, actual);
        }
    }
}
