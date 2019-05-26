using funclib.Collections.Generic;

namespace funclib.Components.Core.Generic
{
    public partial class Stuff
    {
        public static T First<T>(ASeq<T> coll)
        {
            if (coll is null)
            {
                return default;
            }

            return coll.First();
        }

        public static T First<T>(T[] coll)
        {
            var seq = Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.First();
        }

        public static T First<T>(System.Collections.Generic.IEnumerable<T> coll)
        {
            var seq = Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.First();
        }

        public static T First<T>(ISeqable<T> coll)
        {
            var seq = Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.First();
        }

        // public T Invoke(Core.LazySeq<T> coll)
        // {
        //     throw new System.NotImplementedException();
        // }

        public static char First<T>(string coll)
        {
            var seq = Seq(coll);

            if (seq is null)
            {
                return default;
            }

            return seq.First();
        }
    }
}