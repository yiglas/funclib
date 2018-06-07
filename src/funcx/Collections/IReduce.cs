using FunctionalLibrary.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IReduce
    {
        object Reduce(IFunction<object, object, object> f);
        object Reduce(IFunction<object, object, object> f, object init);
    }
}
