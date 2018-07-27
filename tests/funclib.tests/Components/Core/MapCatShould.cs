using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class MapCatShould
    {
        [Test]
        public void MapCat_should_reverse_a_vector_with_vectors_inside()
        {
            var expected = list(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

            var coll = vector(vector(3, 2, 1, 0), vector(6, 5, 4), vector(9, 8, 7));
            var actual = toArray(mapCat(new Reverse(), coll));

            Assert.AreEqual(expected, actual);
        }
    }
}
