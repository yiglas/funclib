using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class KeysShould
    {
        [Test]
        public void Keys_should_return_only_the_keys_of_a_map()
        {
            var expected = funclib.Core.List(":keys", ":some");
            var actual = funclib.Core.Keys(funclib.Core.ArrayMap(":keys", "and", ":some", "values"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keys_should_return_null_if_empty_map()
        {
            Assert.IsNull(funclib.Core.Keys(funclib.Core.ArrayMap()));
        }

        [Test]
        public void Keys_should_return_null_if_passed_null()
        {
            Assert.IsNull(funclib.Core.Keys(null));
        }
    }
}
