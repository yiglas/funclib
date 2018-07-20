using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class TakeLastShould
    {
        [Test]
        public void TakeLast_should_return_last_number()
        {
            var expected = new funclib.Components.Core.List().Invoke(3, 4);
            var actual = new TakeLast().Invoke(2, new Vector().Invoke(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeLast_should_return_complete_list_if_number_is_greater_than_list()
        {
            var expected = new funclib.Components.Core.List().Invoke(4);
            var actual = new TakeLast().Invoke(2, new Vector().Invoke(4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TakeLast_should_return_null_with_empty_coll()
        {
            Assert.IsNull(new TakeLast().Invoke(2, new Vector().Invoke()));
        }

        [Test]
        public void TakeLast_should_return_null_with_null_coll()
        {
            Assert.IsNull(new TakeLast().Invoke(2, null));
        }

        [Test]
        public void TakeLast_should_return_null_with_neg_number()
        {
            var actual = new TakeLast().Invoke(-1, new Vector().Invoke(4));
        }
    }
}
