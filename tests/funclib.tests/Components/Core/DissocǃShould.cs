using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DissocǃShould
    {
        [Test]
        public void Dissocǃ_should_return_the_same_object_without_the_give_key()
        {
            var expected = funclib.Core.Transient(funclib.Core.HashMap("a", 1, "b", 2, "c", 3));
            var actual = funclib.Core.Dissocǃ(expected, "c");

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Dissocǃ_should_return_the_same_object_without_all_the_given_keys()
        {
            var expected = funclib.Core.Transient(funclib.Core.HashMap("a", 1, "b", 2, "c", 3, "d", 4, "e", 5, "f", 6));
            var actual = funclib.Core.Dissocǃ(expected, "a", "c", "e");

            Assert.IsTrue(expected == actual);
        }
    }
}
