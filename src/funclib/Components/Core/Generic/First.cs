using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class First<T> :
        IFunction<ASeq<T>, T>,
    //   IFunction<LazySeq<T>, T>,
        IFunction<ISeqable<T>, T>,
        IFunction<T[], T>,
        IFunction<System.Collections.Generic.IEnumerable<T>, T>,
        IFunction<string, char>
    {
        public T Invoke(ASeq<T> coll)
        {
            if (coll is null)
                return default;

            return coll.First();
        }

        public T Invoke(T[] coll) 
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.First();
        }

        public T Invoke(System.Collections.Generic.IEnumerable<T> coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.First();
        }

        public T Invoke(ISeqable<T> coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.First();
        }

        // public T Invoke(Core.LazySeq<T> coll)
        // {
        //     throw new System.NotImplementedException();
        // }

        public char Invoke(string coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);
            if (seq is null)
                return default;
            return seq.First();
        }
  }
}