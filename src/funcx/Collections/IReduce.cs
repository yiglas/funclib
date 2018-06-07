using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IReduce
    {
        object Reduce(IFunction<object, object, object> f);
        object Reduce(IFunction<object, object, object> f, object init);
    }
}
