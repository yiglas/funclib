using System;
using System.Text;

namespace funclib.Collections.Internal
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

        public System.Collections.DictionaryEntry Entry => new System.Collections.DictionaryEntry(Key, Value);

        public object Key => ((KeyValuePair)this._enumerator.Current).Key;

        public object Value => ((KeyValuePair)this._enumerator.Current).Value;

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
