using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class AssocInShould
    {
        [Test]
        public void AssocIn_should_update_item_in_vector()
        {
            var expected = funclib.Core.Vector(funclib.Core.HashMap("Name", "James", "Age", 26), funclib.Core.HashMap("Name", "John", "Age", 44));
            var map = funclib.Core.Vector(funclib.Core.HashMap("Name", "James", "Age", 26), funclib.Core.HashMap("Name", "John", "Age", 26));
            var actual = funclib.Core.AssocIn(map, funclib.Core.Vector(1, "Age"), 44);

            Assert.AreEqual(expected, actual);
        }
    }
}
