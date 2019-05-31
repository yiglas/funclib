using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class Cons<T> :        
        IFunction<T, ISeq<T>, ISeq<T>>
    {
        public ISeq<T> Invoke(T x, ISeq<T> seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List(x);
            }

            return new Collections.Generic.Cons<T>(x, seq);
        }
    }
}
