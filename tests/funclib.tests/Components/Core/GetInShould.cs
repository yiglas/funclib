using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class GetInShould
    {
        [Test]
        public void GetIn_should_return_the_value_from_a_deep_structure()
        {
            var expected = "Sally Functional";
            var actual = getIn(new System.Collections.Generic.Dictionary<string, object>()
            {
                ["username"] = "sally",
                ["profile"] = new System.Collections.Generic.Dictionary<string, object>()
                {
                    ["name"] = "Sally Functional",
                    ["address"] = new System.Collections.Generic.Dictionary<string, object>()
                    {
                        ["city"] = "Irvine",
                        ["state"] = "CA"
                    }
                }
            }, vector("profile", "name"));

            Assert.AreEqual(expected, actual);
        }


    }
}
