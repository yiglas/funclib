﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class NNextShould
    {
        [Test]
        public void NNext_should_return_the_rest_of_the_list_skipping_the_first_two()
        {
            var expected = new funclib.Components.Core.List().Invoke(3);
            var actual = new NNext().Invoke(new funclib.Components.Core.List().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NNext_should_return_null_if_nothing_is_passed_two_items()
        {
            var actual = new NNext().Invoke(new funclib.Components.Core.List().Invoke(1, 2));

            Assert.IsNull(actual);
        }

        [Test]
        public void NNext_should_return_null_if_empty_list()
        {
            var actual = new NNext().Invoke(new funclib.Components.Core.List().Invoke());

            Assert.IsNull(actual);
        }
    }
}