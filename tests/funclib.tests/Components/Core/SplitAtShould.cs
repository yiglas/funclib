using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class SplitAtShould
    {
        [Test]
        public void SplitAt_should_split_a_vector_at_the_given_number()
        {
            var expected = new Vector().Invoke(new funclib.Components.Core.List().Invoke(1, 2), new funclib.Components.Core.List().Invoke(3, 4, 5));
            var actual = new SplitAt().Invoke(2, new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SplitAt_should_return_empty_list_if_list_greater_then_count_of_coll()
        {
            var expected = new Vector().Invoke(new funclib.Components.Core.List().Invoke(1, 2), new funclib.Components.Core.List().Invoke());
            var actual = new SplitAt().Invoke(3, new Vector().Invoke(1, 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
