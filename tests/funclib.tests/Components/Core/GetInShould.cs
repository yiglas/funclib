using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

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

        [Test]
        public void GetIn_should_return_the_notFound_if_key_doesnot_exist()
        {
            var expected = "Unknown";
            var actual = getIn(null, vector("profile", "name"), "Unknown");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIn_should_return_value_if_exists_even_when_given_notFound()
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
            }, vector("profile", "name"), "Unknown");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIn_should_return_null_if_not_exists()
        {
            Assert.IsNull(getIn(null, vector("profile", "name")));
        }
    }
}
