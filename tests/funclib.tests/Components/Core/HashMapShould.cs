using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class HashMapShould
    {
        [Test]
        public void HashMap_should_create_in_correct_order()
        {
            var actual = funclib.Core.HashMap(":a", 1, ":b", 2, ":c", 3, ":d", 4, ":e", 5);
        }
    }
}
