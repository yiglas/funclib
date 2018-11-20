using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class Next<T> :
        IFunction<ASeq<T>, ISeq<T>>,
    //   IFunction<LazySeq<T>, ISeq<T>>,
        IFunction<ISeqable<T>, ISeq<T>>,
        IFunction<T[], ISeq<T>>,
        IFunction<System.Collections.Generic.IEnumerable<T>, ISeq<T>>,
        IFunction<string, ISeq<char>>
    {
        public ISeq<T> Invoke(ASeq<T> coll)
        {
            if (coll is null)
                return default;

            return coll.Next();
        }

        public ISeq<T> Invoke(T[] coll) 
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.Next();
        }

        public ISeq<T> Invoke(System.Collections.Generic.IEnumerable<T> coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.Next();
        }

        public ISeq<T> Invoke(ISeqable<T> coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.Next();
        }

        // public T Invoke(Core.LazySeq<T> coll)
        // {
        //     throw new System.NotImplementedException();
        // }

        public ISeq<char> Invoke(string coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.Next();
        }
  }
}