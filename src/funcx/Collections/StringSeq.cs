using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    public class StringSeq :
        ASeq,
        IIndexedSeq
    {
        
        public string S { get; }
        public int I { get; }

        StringSeq(string s, int i)
        {
            S = s;
            I = i;
        }

        #region Creates
        public static StringSeq Create(string s) => s.Length == 0 ? null : new StringSeq(s, 0);
        #endregion

        #region Overrides
        public override object First() => S[I];
        public override ISeq Next() => I + 1 < S.Length ? new StringSeq(S, I + 1) : null;
        public override int Count => I < S.Length ? S.Length - I : 0;
        #endregion

        public int Index() => I;

        public override IStack Pop() => throw new NotImplementedException();
    }
}
