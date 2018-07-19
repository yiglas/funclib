﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace funclib.Tests.Components.Core
{
    public class PeekShould
    {
        //[Test]
        //public void Peek_should_be_more_efficient_than_last_for_large_vectors()
        //{
        //    var largeVec = new Vec().Invoke(new Range().Invoke(0, 100));

        //    var sw = Stopwatch.StartNew();
        //    var actual = new Peek().Invoke(largeVec);
        //    sw.Stop();
        //    var peekTime = sw.ElapsedMilliseconds;

        //    sw.Restart();
        //    new Last().Invoke(largeVec);
        //    sw.Stop();
        //    var lastTime = sw.ElapsedMilliseconds;

        //    Assert.LessOrEqual(peekTime, lastTime);
        //}

        [Test]
        public void Peek_should_return_the_last_element_of_a_vector()
        {
            var expected = 3;
            var actual = new Peek().Invoke(new Vector().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_should_return_the_first_element_of_a_list()
        {
            var expected = 1;
            var actual = new Peek().Invoke(new funclib.Components.Core.List().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_should_return_null_if_empty_vector()
        {
            Assert.IsNull(new Peek().Invoke(new Vector().Invoke()));
        }

        [Test]
        public void Peek_should_return_null_when_null_is_passed()
        {
            Assert.IsNull(new Peek().Invoke(null));
        }

        [Test]
        public void Peek_should_return_null_if_empty_list()
        {
            Assert.IsNull(new Peek().Invoke(new funclib.Components.Core.List().Invoke()));
        }
    }
}
