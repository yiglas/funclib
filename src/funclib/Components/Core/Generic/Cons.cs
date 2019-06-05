using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public class Cons :
        IFunction<char, string, ISeq<char>>
    {
        public ISeq<char> Invoke(char x, string seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<char>(x);
            }

            return new Collections.Generic.Cons<char>(x, funclib.Generic.Core.Seq(seq));
        }
    }

    public class Cons<T> :
        IFunction<T, ISeq<T>, ISeq<T>>,
        IFunction<T, ASeq<T>, ISeq<T>>,
        // IFunction<LazySeq<T>, ISeq<T>>,
        IFunction<T, ISeqable<T>, ISeq<T>>,
        IFunctionParams<T, T, ISeq<T>>,
        IFunction<T, System.Collections.Generic.IEnumerable<T>, ISeq<T>>,
        IFunction<T, T, ISeq<T>>
    {
        public ISeq<T> Invoke(T x, ISeq<T> seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<T>(x);
            }

            return new Collections.Generic.Cons<T>(x, seq);
        }

        public ISeq<T> Invoke(T x, ASeq<T> seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<T>(x);
            }

            return new Collections.Generic.Cons<T>(x, funclib.Generic.Core.Seq(seq));
        }

        public ISeq<T> Invoke(T x, ISeqable<T> seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<T>(x);
            }

            return new Collections.Generic.Cons<T>(x, funclib.Generic.Core.Seq(seq));
        }

        public ISeq<T> Invoke(T x, params T[] seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<T>(x);
            }

            return new Collections.Generic.Cons<T>(x, funclib.Generic.Core.Seq(seq));
        }

        public ISeq<T> Invoke(T x, System.Collections.Generic.IEnumerable<T> seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<T>(x);
            }

            return new Collections.Generic.Cons<T>(x, funclib.Generic.Core.Seq(seq));
        }

        public ISeq<T> Invoke(T x, T seq)
        {
            if (seq is null)
            {
                return funclib.Generic.Core.List<T>(x);
            }

            return new Collections.Generic.Cons<T>(x, funclib.Generic.Core.Seq(seq));
        }
    }
}
