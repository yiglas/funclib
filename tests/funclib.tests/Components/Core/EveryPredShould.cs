﻿using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class EveryPredShould
    {
        [Test]
        public void EveryPred_should_return_true_if_all_preds_return_logical_true()
        {
            var actaul = funclib.Core.Invoke(funclib.Core.EveryPred(funclib.Core.isNumber, funclib.Core.isOdd), 3, 9, 11);

            Assert.IsTrue((bool)actaul);
        }
    }
}
