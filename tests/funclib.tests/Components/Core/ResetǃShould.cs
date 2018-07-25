using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ResetǃShould
    {
        [Test]
        public void Resetǃ_should_rest_the_atom_value()
        {
            var x = atom(10);
            var expected = vector(10, 20);
            var actual = resetǃ(x, 20);

            Assert.AreEqual(expected, actual);
        }
    }
}
