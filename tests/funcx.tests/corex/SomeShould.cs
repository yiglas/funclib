﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class SomeShould
    {
        [Test]
        public void Some_should_return_true_if_list_contains_even()
        {
            var actual = some(iseven, new int[] { 1, 2, 3, 4 });

            Assert.True(actual);
        }
    }
}