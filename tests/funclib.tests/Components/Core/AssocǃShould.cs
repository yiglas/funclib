using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class AssocǃShould
    {
        [Test]
        public void Assocǃ_should_update_map_and_not_return_new()
        {
            var expected = funclib.Core.HashMap(":x", 1, ":y", 2, ":z", 3);
            var actual = funclib.Core.Persistentǃ(funclib.Core.Assocǃ(funclib.Core.Transient(expected), ":x", 1, ":y", 2, ":z", 3));

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(expected == actual);
        }

        [Test]
        public void Assocǃ_should_mutate_give_map()
        {
            var expected = funclib.Core.Transient(funclib.Core.HashMap(":x", 1, ":y", 2, ":z", 3));
            var actual = funclib.Core.Assocǃ(expected, ":x", 1, ":y", 2, ":z", 3);

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(expected == actual);
        }
    }
}
