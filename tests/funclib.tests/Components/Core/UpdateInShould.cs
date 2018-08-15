using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class UpdateInShould
    {
        [Test]
        public void UpdateIn_should_update_single_value_in_nested_strcuture()
        {
            var expected = funclib.Core.Vector(funclib.Core.HashMap(":name", "James", ":age", 26), funclib.Core.HashMap(":name", "John", ":age", 44));
            var users = funclib.Core.Vector(funclib.Core.HashMap(":name", "James", ":age", 26), funclib.Core.HashMap(":name", "John", ":age", 43));

            var actual = funclib.Core.UpdateIn(users, funclib.Core.Vector(1, ":age"), new Inc());

            Assert.AreEqual(expected, actual);
        }
    }
}
