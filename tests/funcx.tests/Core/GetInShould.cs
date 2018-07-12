using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class GetInShould
    {
        [Test]
        public void GetIn_should_return_the_value_from_a_deep_structure()
        {
            var expected = "Sally Functional";
            var actual = new GetIn().Invoke(new System.Collections.Generic.Dictionary<string, object>()
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
            }, new Vector().Invoke("profile", "name"));

            Assert.AreEqual(expected, actual);
        }


    }
}
