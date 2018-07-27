﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class NotEmptyShould
    {
        [Test]
        public void NotEmpty_should_return_null_for_empty_collections()
        {
            Assert.IsNull(notEmpty(vector()));
            Assert.IsNull(notEmpty(list()));
            Assert.IsNull(notEmpty(hashMap()));
            Assert.IsNull(notEmpty(null));
        }

        [Test]
        public void NotEmpty_should_return_the_object_if_collection_is_not_empty()
        {
            var expected = vector(1, 2, 3);
            var actual = notEmpty(expected);

            Assert.IsTrue(expected == actual);
        }
    }
}
