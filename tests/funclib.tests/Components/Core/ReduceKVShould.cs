using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReduceKVShould
    {
        [Test]
        public void ReduceKV_should_be_able_to_swap_key_and_values_in_a_map()
        {
            var expected = arrayMap(1, ":a", 2, ":b", 3, ":c");
            var actual = new ReduceKV().Invoke(
                new Function<object, object, object, object>((_1, _2, _3) => assoc(_1, _3, _2)),
                arrayMap(),
                arrayMap(":a", 1, ":b", 2, ":c", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
