using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SplitWithShould
    {
        [Test]
        public void SplitWith_should_split_on_function()
        {
            var expected = funclib.Core.Vector(funclib.Core.List(1, 2, 3), funclib.Core.List(4, 5));
            var actual = funclib.Core.SplitWith(funclib.Core.Partial(new IsGreaterThanOrEqualTo(), 3), funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SplitWith_should_return_empty_list_if_greater_function_doesnot_return_records()
        {
            var expected = funclib.Core.Vector(funclib.Core.List(1, 2, 3, 2, 1), funclib.Core.List());
            var actual = funclib.Core.SplitWith(funclib.Core.Partial(new IsGreaterThan(), 10), funclib.Core.Vector(1, 2, 3, 2, 1));

            Assert.AreEqual(expected, actual);
        }
    }
}
