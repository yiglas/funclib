using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class MapCatShould
    {
        [Test]
        public void MapCat_should_reverse_a_vector_with_vectors_inside()
        {
            var expected = list(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);

            var coll = new Vector().Invoke(new Vector().Invoke(3, 2, 1, 0), new Vector().Invoke(6, 5, 4), new Vector().Invoke(9, 8, 7));
            var actual = new ToArray().Invoke(new MapCat().Invoke(new Reverse(), coll));

            Assert.AreEqual(expected, actual);
        }
    }
}
