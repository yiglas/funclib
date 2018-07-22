using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class NotEmptyShould
    {
        [Test]
        public void NotEmpty_should_return_null_for_empty_collections()
        {
            Assert.IsNull(new NotEmpty().Invoke(new Vector().Invoke()));
            Assert.IsNull(new NotEmpty().Invoke(new funclib.Components.Core.List().Invoke()));
            Assert.IsNull(new NotEmpty().Invoke(hashMap()));
            Assert.IsNull(new NotEmpty().Invoke(null));
        }

        [Test]
        public void NotEmpty_should_return_the_object_if_collection_is_not_empty()
        {
            var expected = new Vector().Invoke(1, 2, 3);
            var actual = new NotEmpty().Invoke(expected);

            Assert.IsTrue(expected == actual);
        }
    }
}
