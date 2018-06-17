﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class GroupByShould
    {
        [Test]
        public void GroupBy_should_group_a_given_collection_by_the_function()
        {
            var expected = new HashMap().Invoke(false, new Vector().Invoke(0, 2, 4, 6, 8), true, new Vector().Invoke(1, 3, 5, 7, 9));
            var actual = new GroupBy().Invoke(new IsOdd(), new Range().Invoke(10));

            Assert.AreEqual(expected, actual);
        }
    }
}