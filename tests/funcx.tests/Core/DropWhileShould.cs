using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class DropWhileShould
    {
        [Test]
        public void DropWhile_should_return_a_list_with_item_after_first_false()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(1, 2, 4, -5, -6, 0, 1);
            var actual = new ToArray().Invoke(new DropWhile().Invoke(new IsNeg(), new Vector().Invoke(-1, -2, -6, -7, 1, 2, 4, -5, -6, 0, 1)));

            Assert.AreEqual(expected, actual);
        }
    }
}
