using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PopShould
    {
        [Test]
        public void Pop_should_return_same_as_the_input_type()
        {
            var actual = pop(new Vector().Invoke(1, 2, 3));

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Pop_should_return_all_but_first_for_vectors()
        {
            var expected = new Vector().Invoke(1, 2);
            var actual = pop(new Vector().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pop_should_return_null_if_past_empty_seq()
        {
            Assert.Throws<InvalidOperationException>(() => pop(new Vector().Invoke()));
        }
    }
}
