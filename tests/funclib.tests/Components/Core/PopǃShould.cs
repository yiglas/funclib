using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class PopǃShould
    {
        [Test]
        public void Popǃ_should_return_itself()
        {
            var expected = funclib.Core.Transient(funclib.Core.Vector(1, 2, 3));
            var actual = funclib.Core.Popǃ(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Popǃ_should_modify_the_original_structure()
        {
            var expected = funclib.Core.Transient(funclib.Core.Vector(1, 2, 3));
            var actual = funclib.Core.Popǃ(expected);

            Assert.AreEqual(2, funclib.Core.Count(expected));
        }
    }
}
