using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ButLastShould
    {
        [Test]
        public void ButLast_should_return_all_but_last_item()
        {
            var expected = funclib.Core.Vector(1, 2);
            var actual = funclib.Core.ButLast(funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ButLast_should_return_null_if_empty_list_passed()
        {
            var actual = funclib.Core.ButLast(funclib.Core.Vector());

            Assert.IsNull(actual);
        }

        [Test]
        public void ButLast_should_return_null_if_passed_null()
        {
            var actual = funclib.Core.ButLast(null);

            Assert.IsNull(actual);
        }
    }
}
