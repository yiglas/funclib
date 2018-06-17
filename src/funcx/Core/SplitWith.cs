using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class SplitWith :
        IFunction<object, object, object>
    {
        public object Invoke(object pred, object coll) =>
            new Vector().Invoke(new TakeWhile().Invoke(pred, coll), new DropWhile().Invoke(pred, coll));
    }
}
