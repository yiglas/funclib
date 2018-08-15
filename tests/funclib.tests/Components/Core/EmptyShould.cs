using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class EmptyShould
    {
        [Test]
        public void Empty_should_return_an_emtpy_collection()
        {
            var expected = funclib.Core.Vector();
            var actual = funclib.Core.Empty(funclib.Core.Vector(1, 2, 3));

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
