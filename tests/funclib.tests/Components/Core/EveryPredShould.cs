using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class EveryPredShould
    {
        [Test]
        public void EveryPred_should_return_true_if_all_preds_return_logical_true()
        {
            var actaul = ((IFunction<object, object, object, object>)new EveryPred().Invoke(new IsNumber(), new IsOdd())).Invoke(3, 9, 11);

            Assert.IsTrue((bool)actaul);
        }
    }
}
