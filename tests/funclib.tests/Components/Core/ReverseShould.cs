using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReverseShould
    {
        [Test]
        public void Reverse_should_reverse_a_sequence_of_items()
        {
            var expected = funclib.Core.List(3, 2, 1);
            var actual = funclib.Core.Reverse(funclib.Core.List(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
