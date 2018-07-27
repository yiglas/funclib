using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class VecShould
    {
        [Test]
        public void Vec_should_create_a_vector_from_a_ISeq()
        {
            var expected = vector(1, 2, 3);
            var actual = vec(hashSet(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vec_should_return_empty_vector_when_past_null()
        {
            var actual = vec(null);

            Assert.AreEqual(0, count(actual));
        }

        [Test]
        public void Vec_should_return_empty_vector_when_past_empty_list()
        {
            var actual = vec(list());

            Assert.AreEqual(0, count(actual));
        }
    }
}
