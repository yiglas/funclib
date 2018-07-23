using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DropWhileShould
    {
        [Test]
        public void DropWhile_should_return_a_list_with_item_after_first_false()
        {
            var expected = list(1, 2, 4, -5, -6, 0, 1);
            var actual = toArray(dropWhile(new IsNeg(), vector(-1, -2, -6, -7, 1, 2, 4, -5, -6, 0, 1)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropWhile_should_return_empty_list_if_pred_always_returns_false()
        {
            var expected = list();
            var actual = toArray(dropWhile(partial(new IsGreaterThan(), 10), vector(1, 2, 3, 2, 1)));

            Assert.AreEqual(expected, actual);
        }
    }
}
