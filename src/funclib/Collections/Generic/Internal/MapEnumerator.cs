using System;
using System.Collections;
using System.Collections.Generic;

namespace funclib.Collections.Generic.Internal
{ class MapEnumerator<TKey, TValue> :
        System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>>,
        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>,
        IDisposable
    {
        bool _disposed = false;
        readonly Enumerator<IKeyValuePair<TKey, TValue>> _enumerator;

        public MapEnumerator(IMap<TKey, TValue> map)
        {
            this._enumerator = new Enumerator<IKeyValuePair<TKey, TValue>>(map.Seq());
        }

        public TKey Key => this._enumerator.Current.Key;

        public TValue Value => this._enumerator.Current.Value;

        public IKeyValuePair<TKey, TValue> Current => this._enumerator.Current;

        object IEnumerator.Current => this._enumerator.Current;

        System.Collections.Generic.KeyValuePair<TKey, TValue> IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>>.Current => new System.Collections.Generic.KeyValuePair<TKey, TValue>(Key, Value);

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