using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReduceKVShould
    {
        [Test]
        public void ReduceKV_should_be_able_to_swap_key_and_values_in_a_map()
        {
            var expected = funclib.Core.ArrayMap(1, ":a", 2, ":b", 3, ":c");
            var actual = funclib.Core.ReduceKV(
                new Function<object, object, object, object>((_1, _2, _3) => funclib.Core.Assoc(_1, _3, _2)),
                funclib.Core.ArrayMap(),
                funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
