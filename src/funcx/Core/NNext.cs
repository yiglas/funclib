using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class NNext :
        IFunction<object, ISeq>
    {
        public ISeq Invoke(object x) => new Next().Invoke(new Next().Invoke(x));
    }
}
