using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IReduce
    {
        object Reduce(IFunction f);
        object Reduce(IFunction f, object init);
    }
}
