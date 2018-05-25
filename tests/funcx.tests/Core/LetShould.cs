using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funcx.core;

namespace funcx.tests.Core
{
    public class LetShould
    {
        [Test]
        public void Let_should()
        {
            var id = let<int, string, int>((1, "Devin"), ((int id, string name) x) => x.id);

            Assert.AreEqual(1, id);
        }

        [Test]
        public void Let_should_run_func()
        {
            Func<int> getId = () => 1;

            var id = let<int, string, int>((getId(), "Devin"), ((int id, string name) x) => x.id);

            Assert.AreEqual(1, id);
        }
    }
}
