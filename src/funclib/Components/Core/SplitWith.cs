using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SplitWith :
        IFunction<object, object, object>
    {
        public object Invoke(object pred, object coll) =>
            new Vector().Invoke(new TakeWhile().Invoke(pred, coll), new DropWhile().Invoke(pred, coll));
    }
}
