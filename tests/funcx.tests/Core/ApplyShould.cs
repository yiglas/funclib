using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ApplyShould
    {
        [Test]
        public void Apply_should_apply_each_item_in_array_to_the_function()
        {
            var expected = "str1str2str3";
            var actual = new Apply().Invoke(new Str(), new Vector().Invoke("str1", "str2", "str3"));

            Assert.AreEqual(expected, actual);
        }
    }
}
