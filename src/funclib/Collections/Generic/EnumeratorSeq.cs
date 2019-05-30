using funclib.Components.Core.Generic;

namespace funclib.Collections.Generic
{
    public class EnumeratorSeq<T> :
        IFunction<T>
    {
        System.Collections.Generic.IEnumerator<T> _enumerator;

        EnumeratorSeq(System.Collections.Generic.IEnumerator<T> enumerator)
        {
            this._enumerator = enumerator;
        }

        #region Creates
        public static ISeq<T> Create
        #endregion
    }
}
