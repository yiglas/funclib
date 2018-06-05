using FunctionalLibrary.Core;
using FunctionalLibrary.Tests.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class ConjShould
    {
        [Test]
        public void Conj_should_will_create_a_new_list_with_all_the_value_from_old_list_plus_new_items_passed_in()
        {
            var list = new List<string>();
            var actual = conj(list, "test");

            Assert.AreNotSame(list, actual);
        }

        [Test]
        public void Conj_should_add_new_items_to_end_of_list()
        {
            var list = new List<string>{ "1", "2", "3" };
            var actual = conj(list, "4", "5");

            Assert.AreEqual(actual[3], "4");
            Assert.AreEqual(actual[4], "5");
        }

        [Test]
        public void Conj_should_return_new_list_if_source_is_null_and_no_items_passed_in()
        {
            var actual = conj<string>(null);

            Assert.NotNull(actual);
        }

        [Test]
        public void Conj_should_return_new_list_with_items_passed_if_source_is_null()
        {
            var actual = conj(null, "test", "next");

            Assert.AreEqual(actual[0], "test");
            Assert.AreEqual(actual[1], "next");
        }

        [Test]
        public void Perfomance()
        {
            var perf = new ConjPerformance();
            var results = perf.Measure();

            Assert.Greater(results.baseline + 10, results.b);
        }

        //[Test]
        //public void Test()
        //{
        //    var acutal = new Conj<int>().Invoke(null, 1);
        //    var a2 = new Conj<int>().Invoke(null, 1, 2, 3);
        //    var a3 = new Conj<int>().Invoke(new List<int>() { 4, 5, 6 }, 1, 2, 3);
        //}

    }

    public class ConjPerformance : Performance
    {
        const int DEFAULT_ITERATIONS = 100;
        const int LIST_SIZE = 1000;
        const int WORD_SIZE = 5;

        char[] array = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        List<string> baselineList = new List<string>();
        List<string> measureTestBList = new List<string>();

        public ConjPerformance() : base("Conj", "", DEFAULT_ITERATIONS)
        {
            this.baselineList = GenerateList();
            this.measureTestBList = GenerateList();
        }

        List<string> GenerateList()
        {
            var random = new Random();
            var list = new List<string>();
            for (int i = 0; i < LIST_SIZE; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < WORD_SIZE; j++)
                {
                    int index = random.Next(this.array.Length);
                    sb.Append(this.array[index]);
                }
                list.Add(sb.ToString());
            }
            return list;
        }

        protected override bool BaselineTest()
        {
            for (int i = 0; i < this.Iterations; i++)
            {
                this.baselineList.Add("---");
            }
            return true;
        }

        protected override bool MeasureTestB()
        {
            for (int i = 0; i < this.Iterations; i++)
            {
                conj(this.measureTestBList, "---");
            }
            return true;
        }

        protected override bool MeasureTestC() => false;
    }
}
