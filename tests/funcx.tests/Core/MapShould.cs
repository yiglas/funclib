﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class MapShould
    {
        [Test]
        public void Map_should_apply_function_to_each_item_passed()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(2, 3, 4, 5, 6);
            var actual = new Map().Invoke(new Inc(), new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
