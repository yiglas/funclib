﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsFunctionShould
    {
        [Test]
        public void IsFunction_should_return_true_if_an_object_is_IFunction()
        {
            Assert.IsTrue((bool)isFunction(new Vector()));
        }

        [Test]
        public void IsFunction_should_return_false_if_an_object_is_not_IFunction()
        {
            Assert.IsFalse((bool)isFunction(1));
            Assert.IsFalse((bool)isFunction(null));
        }
    }
}
