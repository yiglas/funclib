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
            Assert.IsTrue((bool)new IsSet().Invoke(hashSet(1, 2, 3)));
            Assert.IsTrue((bool)new IsSet().Invoke(new SortedSet().Invoke(1, 2, 3)));
        }

        [Test]
        public void IsSet_should_return_false_if_not_reduced()
        {
            Assert.IsFalse((bool)new IsSet().Invoke(new Vector().Invoke(1, 2, 3)));
        }
    }
}
