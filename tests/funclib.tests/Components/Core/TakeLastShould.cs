using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class TakeLastShould
    {
        [Test]
        public void TakeLast_should_return_last_number()
        {
            var expected = list(3, 4);
            var actual = takeLast(2, new Vector().Invoke(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeLast_should_return_complete_list_if_number_is_greater_than_list()
        {
            var expected = list(4);
            var actual = takeLast(2, new Vector().Invoke(4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeLast_should_return_null_with_empty_coll()
        {
            Assert.IsNull(takeLast(2, new Vector().Invoke()));
        }

        [Test]
        public void TakeLast_should_return_null_with_null_coll()
        {
            Assert.IsNull(takeLast(2, null));
        }

        [Test]
        public void TakeLast_should_return_null_with_neg_number()
        {
            var actual = takeLast(-1, new Vector().Invoke(4));
        }
    }
}
