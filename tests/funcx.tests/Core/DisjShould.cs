using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Core
{
    public class DisjShould
    {
        [Test]
        public void Disj_should_return_new_list_even_if_nothing_is_passed()
        {
            var expected = new List<int>(){ 1, 2, 3 };
            var actual = disj(expected);

            Assert.AreNotSame(expected, actual);
        }

        [Test]
        public void Disj_should_return_new_list_without_passed_in_item()
        {
            var expected = new List<int>() { 1, 2, 3 };
            var actual = disj(expected, 1);

            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        public void Disj_should_return_new_list_without_passed_in_items()
        {
            var expected = new List<int>() { 1, 2, 3 };
            var actual = disj(expected, 1, 3);

            Assert.AreEqual(1, actual.Count);
        }

        [Test]
        public void Disj_should_return_new_list_event_if_items_doesnot_exists()
        {
            var expected = new List<int>() { 1, 2, 3 };
            var actual = disj(expected, 4);

            Assert.AreEqual(3, actual.Count);
        }
    }
}
