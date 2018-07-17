using funclib.Components.Core;
using System;
using System.Text;

namespace funclib.Collections
{
    public interface IReduce
    {
        object Reduce(IFunction f);
        object Reduce(IFunction f, object init);
    }
}
