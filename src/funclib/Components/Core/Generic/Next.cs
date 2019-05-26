using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public partial class Stuff
    {
        public static ISeq<T> Next<T>(ASeq<T> coll)
        {
            if (coll is null)
            {
                return default;
            }

            return coll.Next();
        }

        public static ISeq<T> Next<T>(T[] coll)
        {
            var seq = Seq(coll);

            if (coll is null)
            {
                return default;
            }

            return seq.Next();
        }

        public static ISeq<T> Next<T>(System.Collections.Generic.IEnumerable<T> coll)
        {
            var seq = Seq(coll);

            if (coll is null)
            {
                return default;
            }

            return seq.Next();
        }

        public static ISeq<T> Next<T>(ISeqable<T> coll)
        {
            var seq = Seq(coll);

            if (coll is null)
            {
                return default;
            }

            return seq.Next();
        }

        // public T Invoke(Core.LazySeq<T> coll)
        // {
        //     throw new System.NotImplementedException();
        // }

        public static ISeq<char> Next(string coll)
        {
            var seq = Seq(coll);

            if (coll is null)
            {
                return default;
            }

            return seq.Next();
        }
    }
}