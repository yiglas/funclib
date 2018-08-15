using NUnit.Framework;
using System;

namespace funclib.Tests.Components.Core
{
    public class PopShould
    {
        [Test]
        public void Pop_should_return_same_as_the_input_type()
        {
            var actual = funclib.Core.Pop(funclib.Core.Vector(1, 2, 3));

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Pop_should_return_all_but_first_for_vectors()
        {
            var expected = funclib.Core.Vector(1, 2);
            var actual = funclib.Core.Pop(funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pop_should_return_null_if_past_empty_seq()
        {
            Assert.Throws<InvalidOperationException>(() => funclib.Core.Pop(funclib.Core.Vector()));
        }
    }
}
