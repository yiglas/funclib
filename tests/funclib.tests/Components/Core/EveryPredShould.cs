using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class EveryPredShould
    {
        [Test]
        public void EveryPred_should_return_true_if_all_preds_return_logical_true()
        {
            var actaul = invoke(everyPred(IsNumber, IsOdd), 3, 9, 11);

            Assert.IsTrue((bool)actaul);
        }
    }
}
