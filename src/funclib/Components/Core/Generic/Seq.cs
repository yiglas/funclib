using funclib.Collections.Generic;
using funclib.Collections.Generic.Internal;
using System;

namespace funclib.Components.Core.Generic
{
    public class Seq<T> :
        IFunction<ASeq<T>, ISeq<T>>,
        IFunction<ISeqable<T>, ISeq<T>>,
        IFunction<T, ISeq<T>>,
        IFunctionParams<T, ISeq<T>>,
        IFunction<System.Collections.Generic.IEnumerable<T>, ISeq<T>>
    {
        public ISeq<T> Invoke(ASeq<T> coll) => coll;

        public ISeq<T> Invoke(ISeqable<T> coll) => coll?.Seq();

        public ISeq<T> Invoke(T coll)
        {
            throw new NotImplementedException();
        }

        public ISeq<T> Invoke(params T[] coll)
        {
            if (coll is null)
            {
                return null;
            }

            return ArraySeq<T>.Create(coll);
        }

        public ISeq<T> Invoke(System.Collections.Generic.IEnumerable<T> coll)
        {
            throw new NotImplementedException();
        }
    }

    public class Seq :
        IFunction<string, ISeq<char>>
    {
        public ISeq<char> Invoke(string coll)
        {
            if (coll is null)
            {
                return null;
            }

            return StringSeq.Create(s);
        }
    }
}
