using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class SplitWithShould
    {
        [Test]
        public void SplitWith_should_split_on_function()
        {
            var expected = new Vector().Invoke(new funclib.Components.Core.List().Invoke(1, 2, 3), new funclib.Components.Core.List().Invoke(4, 5));
            var actual = new SplitWith().Invoke(new Partial().Invoke(new IsGreaterThanOrEqualTo(), 3), new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SplitWith_should_return_empty_list_if_greater_function_doesnot_return_records()
        {
            var expected = new Vector().Invoke(new funclib.Components.Core.List().Invoke(1, 2, 3, 2, 1), new funclib.Components.Core.List().Invoke());
            var actual = new SplitWith().Invoke(new Partial().Invoke(new IsGreaterThan(), 10), new Vector().Invoke(1, 2, 3, 2, 1));

            Assert.AreEqual(expected, actual);
        }
    }
}
