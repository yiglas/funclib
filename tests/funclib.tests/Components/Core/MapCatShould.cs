using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class MapCatShould
    {
        [Test]
        public void MapCat_should_reverse_a_vector_with_vectors_inside()
        {
            var expected = funclib.Core.List(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

            var coll = funclib.Core.Vector(funclib.Core.Vector(3, 2, 1, 0), funclib.Core.Vector(6, 5, 4), funclib.Core.Vector(9, 8, 7));
            var actual = funclib.Core.ToArray(funclib.Core.MapCat(new Reverse(), coll));

            Assert.AreEqual(expected, actual);
        }
    }
}
