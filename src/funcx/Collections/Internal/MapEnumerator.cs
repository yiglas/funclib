using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class MapEnumerator : 
        System.Collections.IDictionaryEnumerator, 
        IDisposable,
        System.Collections.IEnumerator
    {
        bool _disposed = false;
        readonly Enumerator _enumerator;

        public MapEnumerator(IMap map)
        {
            this._enumerator = new Enumerator(map.Seq());
        }

        public System.Collections.DictionaryEntry Entry => throw new NotImplementedException();

        public object Key => ((System.Collections.Generic.KeyValuePair<object, object>)this._enumerator.Current).Key;

        public object Value => ((System.Collections.Generic.KeyValuePair<object, object>)this._enumerator.Current).Value;

        public object Current => this._enumerator.Current;

        public bool MoveNext() => this._enumerator.MoveNext();
        public void Reset() => this._enumerator.Reset();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._enumerator?.Dispose();
                }
                this._disposed = true;
            }
        }
    }
}
