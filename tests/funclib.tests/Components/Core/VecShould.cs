using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class VecShould
    {
        [Test]
        public void Vec_should_create_a_vector_from_a_ISeq()
        {
            var expected = funclib.Core.Vector(1, 2, 3);
            var actual = funclib.Core.Vec(funclib.Core.HashSet(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vec_should_return_empty_vector_when_past_null()
        {
            var actual = funclib.Core.Vec(null);

            Assert.AreEqual(0, funclib.Core.Count(actual));
        }

        [Test]
        public void Vec_should_return_empty_vector_when_past_empty_list()
        {
            var actual = funclib.Core.Vec(funclib.Core.List());

            Assert.AreEqual(0, funclib.Core.Count(actual));
        }
    }
}
