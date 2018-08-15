using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SubVecShould
    {
        [Test]
        public void SubVec_should_return_a_vector()
        {
            var actual = funclib.Core.SubVec(funclib.Core.Vector(1, 2, 3, 4, 5, 6, 7), 2);

            Assert.IsInstanceOf<funclib.Collections.IVector>(actual);
        }

        [Test]
        public void SubVec_should_return_all_items_after_start()
        {
            var expected = funclib.Core.Vector(3, 4, 5, 6, 7);
            var actual = funclib.Core.SubVec(funclib.Core.Vector(1, 2, 3, 4, 5, 6, 7), 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubVec_should_return_all_items_after_start_but_before_end()
        {
            var expected = funclib.Core.Vector(3, 4);
            var actual = funclib.Core.SubVec(funclib.Core.Vector(1, 2, 3, 4, 5, 6, 7), 2, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}
