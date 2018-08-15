using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DropWhileShould
    {
        [Test]
        public void DropWhile_should_return_a_list_with_item_after_first_false()
        {
            var expected = funclib.Core.List(1, 2, 4, -5, -6, 0, 1);
            var actual = funclib.Core.ToArray(funclib.Core.DropWhile(new IsNeg(), funclib.Core.Vector(-1, -2, -6, -7, 1, 2, 4, -5, -6, 0, 1)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropWhile_should_return_empty_list_if_pred_always_returns_false()
        {
            var expected = funclib.Core.List();
            var actual = funclib.Core.ToArray(funclib.Core.DropWhile(funclib.Core.Partial(new IsGreaterThan(), 10), funclib.Core.Vector(1, 2, 3, 2, 1)));

            Assert.AreEqual(expected, actual);
        }
    }
}
