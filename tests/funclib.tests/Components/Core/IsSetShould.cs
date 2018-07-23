using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsSetShould
    {
        [Test]
        public void IsSet_should_return_true_if_reduced()
        {
            Assert.IsTrue((bool)isSet(hashSet(1, 2, 3)));
            Assert.IsTrue((bool)isSet(sortedSet(1, 2, 3)));
        }

        [Test]
        public void IsSet_should_return_false_if_not_reduced()
        {
            Assert.IsFalse((bool)isSet(new Vector().Invoke(1, 2, 3)));
        }
    }
}
