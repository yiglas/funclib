using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class Next :
        IFunction<string, ISeq<char>>
    {
        public ISeq<char> Invoke(string coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.Next();
        }
    }

    public class Next<T> :
        IFunction<ASeq<T>, ISeq<T>>,
        // IFunction<LazySeq<T>, ISeq<T>>,
        IFunction<ISeqable<T>, ISeq<T>>,
        IFunctionParams<T, ISeq<T>>,
        IFunction<System.Collections.Generic.IEnumerable<T>, ISeq<T>>,
        IFunction<T, ISeq<T>>
    {
        public ISeq<T> Invoke(ASeq<T> coll)
        {
            if (coll is null)
            {
                return default;
            }

            return coll.Next();
        }

        // public T Invoke(LazySeq<T> coll)
        // {
        //     throw new NotImplementedException();
        // }

        public ISeq<T> Invoke(ISeqable<T> coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.Next();
        }

        public ISeq<T> Invoke(params T[] coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.Next();
        }

        public ISeq<T> Invoke(System.Collections.Generic.IEnumerable<T> coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.Next();
        }

        public ISeq<T> Invoke(T coll)
        {
            var seq = funclib.Generic.Core.Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.Next();
        }
    }
}