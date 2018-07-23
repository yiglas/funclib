using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsSortedShould
    {
        [Test]
        public void IsSorted_should_return_true_if_implements_sorted()
        {
            Assert.IsTrue((bool)isSorted(new SortedSet().Invoke(1, 2, 3)));
        }

        [Test]
        public void IsSorted_should_return_false_if_doesnot_implements_sorted()
        {
            Assert.IsFalse((bool)isSorted(new Vector().Invoke(1, 2, 3)));
        }
    }
}
