﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsVolatileShould
    {
        [Test]
        public void IsVolatile_should_return_true_if_volatile()
        {
            Assert.IsTrue((bool)isVolatile(new Volatileǃ().Invoke("foo")));
        }

        [Test]
        public void IsVolatile_should_return_false_if_not_volatile()
        {
            Assert.IsFalse((bool)isVolatile(0));
        }
    }
}
