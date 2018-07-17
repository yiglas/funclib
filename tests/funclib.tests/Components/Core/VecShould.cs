using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class VecShould
    {
        [Test]
        public void Vec_should_create_a_vector_from_a_ISeq()
        {
            var expected = new Vector().Invoke(1, 2, 3);
            var actual = new Vec().Invoke(new HashSet().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Vec_should_return_empty_vector_when_past_null()
        {
            var actual = new Vec().Invoke(null);

            Assert.AreEqual(0, new Count().Invoke(actual));
        }

        [Test]
        public void Vec_should_return_empty_vector_when_past_empty_list()
        {
            var actual = new Vec().Invoke(new funclib.Components.Core.List().Invoke());

            Assert.AreEqual(0, new Count().Invoke(actual));
        }
    }
}
