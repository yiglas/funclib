using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class TakeLastShould
    {
        [Test]
        public void TakeLast_should_return_last_number()
        {
            var expected = funclib.Core.List(3, 4);
            var actual = funclib.Core.TakeLast(2, funclib.Core.Vector(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeLast_should_return_complete_list_if_number_is_greater_than_list()
        {
            var expected = funclib.Core.List(4);
            var actual = funclib.Core.TakeLast(2, funclib.Core.Vector(4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeLast_should_return_null_with_empty_coll()
        {
            Assert.IsNull(funclib.Core.TakeLast(2, funclib.Core.Vector()));
        }

        [Test]
        public void TakeLast_should_return_null_with_null_coll()
        {
            Assert.IsNull(funclib.Core.TakeLast(2, null));
        }

        [Test]
        public void TakeLast_should_return_null_with_neg_number()
        {
            var actual = funclib.Core.TakeLast(-1, funclib.Core.Vector(4));
        }
    }
}
