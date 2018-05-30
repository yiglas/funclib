using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class MapEnumerator : 
        IDictionaryEnumerator, 
        IDisposable, 
        IEnumerator, 
        IEnumerator<KeyValuePair<object, object>>
    {
        bool _disposed = false;
        readonly Enumerator _enumerator;

        public MapEnumerator(IMap map)
        {
            this._enumerator = new Enumerator(map.Seq());
        }

        public DictionaryEntry Entry => throw new NotImplementedException();

        public object Key => ((KeyValuePair<object, object>)this._enumerator.Current).Key;

        public object Value => ((KeyValuePair<object, object>)this._enumerator.Current).Value;

        public object Current => this._enumerator.Current;

        KeyValuePair<object, object> IEnumerator<KeyValuePair<object, object>>.Current => (KeyValuePair<object, object>)this._enumerator.Current;

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
