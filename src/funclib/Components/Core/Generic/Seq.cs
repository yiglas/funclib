using funclib.Collections.Generic;
using System;

namespace funclib.Components.Core.Generic
{
    public class Seq<T> :
        IFunction<ASeq<T>, ISeq<T>>,
        IFunction<ISeq<T>, ISeq<T>>,
        // IFunction<LazySeq<T>, ISeq<T>>,
        IFunction<ISeqable<T>, ISeq<T>>,
        IFunction<T[], ISeq<T>>,
        IFunction<System.Collections.Generic.IEnumerable<T>, ISeq<T>>,
        IFunction<string, ISeq<T>>
    {
        public ISeq<T> Invoke(ASeq<T> coll) => coll;
        public ISeq<T> Invoke(ISeq<T> coll) => coll;

        public ISeq<T> Invoke(ISeqable<T> coll)
        {
            if (coll is null) 
                return null;

            return coll.Seq();
        }

        public ISeq<T> Invoke(T[] coll)
        {
            if (coll is null) 
                return null;
            
            throw new System.NotImplementedException();
        }

        public ISeq<T> Invoke(System.Collections.Generic.IEnumerable<T> coll)
        {
            if (coll is null) 
                return null;

            throw new System.NotImplementedException();
        }

        public ISeq<T> Invoke(string coll)
        {
            if (coll is null) 
                return null;

            throw new System.NotImplementedException();
        }
  }
}
