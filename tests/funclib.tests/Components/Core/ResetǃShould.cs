using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ResetǃShould
    {
        [Test]
        public void Resetǃ_should_rest_the_atom_value()
        {
            var x = funclib.Core.Atom(10);
            var expected = funclib.Core.Vector(10, 20);
            var actual = funclib.Core.Resetǃ(x, 20);

            Assert.AreEqual(expected, actual);
        }
    }
}
