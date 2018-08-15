using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class NotEmptyShould
    {
        [Test]
        public void NotEmpty_should_return_null_for_empty_collections()
        {
            Assert.IsNull(funclib.Core.NotEmpty(funclib.Core.Vector()));
            Assert.IsNull(funclib.Core.NotEmpty(funclib.Core.List()));
            Assert.IsNull(funclib.Core.NotEmpty(funclib.Core.HashMap()));
            Assert.IsNull(funclib.Core.NotEmpty(null));
        }

        [Test]
        public void NotEmpty_should_return_the_object_if_collection_is_not_empty()
        {
            var expected = funclib.Core.Vector(1, 2, 3);
            var actual = funclib.Core.NotEmpty(expected);

            Assert.IsTrue(expected == actual);
        }
    }
}
