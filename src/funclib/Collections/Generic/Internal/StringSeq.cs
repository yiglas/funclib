using System;

namespace funclib.Collections.Generic.Internal
{
    public class StringSeq :
        ASeq<char>,
        IIndexedSeq<char>
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
        public override char First() => S[I];
        public override ISeq<char> Next() => I + 1 < S.Length ? new StringSeq(S, I + 1) : null;
        public override int Count => I < S.Length ? S.Length - I : 0;
        #endregion

        public int Index() => I;

        public override IStack<char> Pop() => throw new NotImplementedException();
    }
}
