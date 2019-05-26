using funclib.Collections.Generic;
using System;

namespace funclib.Components.Core.Generic
{
    public partial class Stuff
    {
        public static ISeq<T> Seq<T>(ASeq<T> coll) => coll;
        public static ISeq<T> Seq<T>(ISeq<T> coll) => coll;

        public static ISeq<T> Seq<T>(ISeqable<T> coll)
        {
            if (coll is null)
            {
                return null;
            }

            return coll.Seq();
        }

        public static ISeq<T> Seq<T>(params T[] coll)
        {
            if (coll is null)
            {
                return null;
            }

            throw new System.NotImplementedException();
        }

        public static ISeq<T> Seq<T>(System.Collections.Generic.IEnumerable<T> coll)
        {
            if (coll is null)
            {
                return null;
            }

            throw new System.NotImplementedException();
        }

        public static ISeq<char> Seq(string coll)
        {
            if (coll is null)
            {
                return null;
            }

            throw new System.NotImplementedException();
        }
    }
}
