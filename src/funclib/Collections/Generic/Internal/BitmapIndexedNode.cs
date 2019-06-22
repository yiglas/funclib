using System;
using System.Threading;
using static funclib.Util;

namespace funclib.Collections.Generic.Internal
{
    sealed class BitmapIndexedNode<TKey, TValue> :
        INode<TKey, TValue>
    {
        public static readonly BitmapIndexedNode<TKey, TValue> EMPTY = new BitmapIndexedNode<TKey, TValue>(null, 0, new UnionType<TKey, TValue, INode<TKey, TValue>>[0]);

        int _bitmap;
        UnionType<TKey, TValue, INode<TKey, TValue>>[] _array;

        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        int Index(int bit) => BitCount(this._bitmap & (bit - 1));

        public BitmapIndexedNode(AtomicReference<Thread> edit, int bitmap, UnionType<TKey, TValue, INode<TKey, TValue>>[] array)
        {
            this._bitmap = bitmap;
            this._array = array;
            this._edit = edit;
        }

        public INode<TKey, TValue> Assoc(int shift, int hash, TKey key, TValue val, Box<object> addedLeaf)
        {
            int bit = Bitpos(hash, shift);
            int idx = Index(bit);
            if ((this._bitmap & bit) != 0)
            {
                var keyOrNull = this._array[2 * idx];
                var valOrNode = this._array[2 * idx + 1];

                if (keyOrNull.HasValue)
                {
                    var n = valOrNode.Item3.Assoc(shift + 5, hash, key, val, addedLeaf);
                    if (n == valOrNode)
                    {
                        return this;
                    }

                    return new BitmapIndexedNode<TKey, TValue>(
                        null,
                        this._bitmap,
                        CloneAndSet(this._array, 2 * idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(n)));
                }

                if (key == keyOrNull)
                {
                    if (val == valOrNode)
                    {
                        return this;
                    }

                    return new BitmapIndexedNode<TKey, TValue>(
                        null,
                        this._bitmap,
                        CloneAndSet(this._array, 2 * idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(val)));
                }

                addedLeaf.Value = addedLeaf;

                return new BitmapIndexedNode<TKey, TValue>(null, this._bitmap,
                    CloneAndSet(this._array,
                                2 * idx,
                                null,
                                2 * idx + 1,
                                UnionType<TKey, TValue, INode<TKey, TValue>>.Create(CreateNode<TKey, TValue>(shift + 5, keyOrNull, valOrNode, hash, key, val))));
            }
            else
            {
                int n = BitCount(this._bitmap);
                if (n >= 16)
                {
                    var nodes = new INode<TKey, TValue>[32];
                    int jdx = Mask(hash, shift);
                    nodes[jdx] = EMPTY.Assoc(shift + 5, hash, key, val, addedLeaf);
                    int j = 0;
                    for (int i = 0; i < 32; i++)
                    {
                        if (((this._bitmap >> i) & 1) != 0)
                        {
                            if (this._array[j].HasValue)
                            {
                                nodes[i] = this._array[j + 1] as INode<TKey, TValue>;
                            }
                            else
                            {
                                nodes[i] = EMPTY.Assoc(shift + 5, GetHash(this._array[j]), this._array[j], this._array[j + 1], addedLeaf);
                            }
                            j += 2;
                        }
                    }

                    return new ArrayNode<TKey, TValue>(null, n + 1, nodes);
                }
                else
                {
                    var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[2 * (n + 1)];
                    System.Array.Copy(this._array, 0, newArray, 0, 2 * idx);
                    newArray[2 * idx] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(key);
                    addedLeaf.Value = addedLeaf;
                    newArray[2 * idx + 1] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(val);
                    System.Array.Copy(this._array, 2 * idx, newArray, 2 * (idx + 1), 2 * (n - idx));

                    return new BitmapIndexedNode<TKey, TValue>(null, this._bitmap | bit, newArray);
                }
            }
        }

        public INode<TKey, TValue> Assoc(AtomicReference<Thread> edit, int shift, int hash, TKey key, TValue val, Box<object> addedLeaf)
        {
            int bit = Bitpos(hash, shift);
            int idx = Index(bit);
            if ((this._bitmap & bit) != 0)
            {
                var keyOrNull = this._array[2 * idx];
                var valOrNode = this._array[2 * idx + 1];

                if (keyOrNull.HasValue)
                {
                    var n = valOrNode.Item3.Assoc(edit, shift + 5, hash, key, val, addedLeaf);
                    if (n == valOrNode)
                    {
                        return this;
                    }

                    return EditAndSet(edit, 2 * idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(n));
                }

                if (key == keyOrNull)
                {
                    if (val == valOrNode)
                    {
                        return this;
                    }

                    return EditAndSet(edit, 2 * idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(val));
                }

                addedLeaf.Value = addedLeaf;

                return EditAndSet(edit,
                    2 * idx,
                    null,
                    2 * idx + 1,
                    UnionType<TKey, TValue, INode<TKey, TValue>>.Create(CreateNode<TKey, TValue>(edit, shift + 5, keyOrNull, valOrNode, hash, key, val)));
            }
            else
            {
                int n = BitCount(this._bitmap);
                if (n * 2 < this._array.Length)
                {
                    addedLeaf.Value = addedLeaf;
                    var editable = EnsureEditable(edit);
                    System.Array.Copy(editable._array, 2 * idx, editable._array, 2 * (idx + 1), 2 * (n - idx));
                    editable._array[2 * idx] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(key);
                    editable._array[2 * idx + 1] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(val);
                    editable._bitmap |= bit;
                    return editable;
                }

                if (n >= 16)
                {
                    var nodes = new INode<TKey, TValue>[32];
                    int jdx = Mask(hash, shift);
                    nodes[jdx] = EMPTY.Assoc(edit, shift + 5, hash, key, val, addedLeaf);
                    int j = 0;
                    for (int i = 0; i < 32; i++)
                    {
                        if (((this._bitmap >> i) & 1) != 0)
                        {
                            if (this._array[j].HasValue)
                            {
                                nodes[i] = this._array[j + 1] as INode<TKey, TValue>;
                            }
                            else
                            {
                                nodes[i] = EMPTY.Assoc(edit, shift + 5, GetHash(this._array[j]), this._array[j], this._array[j + 1], addedLeaf);
                            }

                            j += 2;
                        }
                    }

                    return new ArrayNode<TKey, TValue>(edit, n + 1, nodes);
                }
                else
                {
                    var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[2 * (n + 4)];
                    System.Array.Copy(this._array, 0, newArray, 0, 2 * idx);
                    newArray[2 * idx] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(key);
                    addedLeaf.Value = addedLeaf;
                    newArray[2 * idx + 1] = UnionType<TKey, TValue, INode<TKey, TValue>>.Create(val);
                    System.Array.Copy(this._array, 2 * idx, newArray, 2 * (idx + 1), 2 * (n - idx));
                    var editable = EnsureEditable(edit);
                    editable._array = newArray;
                    editable._bitmap |= bit;
                    return editable;
                }
            }
        }

        public IKeyValuePair<TKey, TValue> Get(int shift, int hash, TKey key)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0)
            {
                return null;
            }

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];

            if (keyOrNull.HasValue)
            {
                return valOrNode.Item3.Get(shift + 5, hash, key);
            }
            if (key == keyOrNull)
            {
                return KeyValuePair<TKey, TValue>.Create(keyOrNull, valOrNode);
            }

            return null;
        }

        public TValue Get(int shift, int hash, TKey key, TValue notFound)
        {
            var value = Get(shift, hash, key);

            if (value == null)
            {
                return notFound;
            }

            return value.Value;
        }

        public System.Collections.Generic.IEnumerator<IKeyValuePair<TKey, TValue>> GetEnumerator(Func<TKey, UnionType<TValue, INode<TKey, TValue>>, IKeyValuePair<TKey, TValue>> d)
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                var key = this._array[i];
                var nodeOrVal = this._array[i + 1];

                if (key.HasValue)
                {
                    var second = UnionType<TValue, INode<TKey, TValue>>.Create(nodeOrVal.Item2);

                    if (nodeOrVal.IsItem2)
                    {
                        second = nodeOrVal.Item2;
                    }

                    yield return d(key.Item1, second);
                }
                else if (nodeOrVal.HasValue)
                {
                    var ie = nodeOrVal.Item3.GetEnumerator(d);
                    while (ie.MoveNext())
                        yield return ie.Current;
                }
            }
        }

        public ISeq<IKeyValuePair<TKey, TValue>> GetNodeEnumerative() => NodeSeq<TKey, TValue>.Create(this._array);

        public TAccumulate Reduce<TAccumulate>(Func<TAccumulate, UnionType<TKey, TValue, INode<TKey, TValue>>, UnionType<TKey, TValue, INode<TKey, TValue>>, TAccumulate> f, TAccumulate init)
        {
            throw new NotImplementedException();
        }

        public INode<TKey, TValue> Without(int shift, int hash, TKey key)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0)
            {
                return this;
            }

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];

            if (!keyOrNull.HasValue)
            {
                var n = valOrNode.Item3.Without(shift + 5, hash, key);

                if (n == valOrNode)
                {
                    return this;
                }

                if (n != null)
                {
                    return new BitmapIndexedNode<TKey, TValue>(
                        null,
                        this._bitmap,
                        CloneAndSet(this._array, 2 * idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(n)));
                }

                if (this._bitmap == bit)
                {
                    return null;
                }

                return new BitmapIndexedNode<TKey, TValue>(null, this._bitmap ^ bit, RemovePair(this._array, idx));
            }

            if (key == keyOrNull)
            {
                return new BitmapIndexedNode<TKey, TValue>(null, this._bitmap ^ bit, RemovePair(this._array, idx));
            }

            return this;
        }

        public INode<TKey, TValue> Without(AtomicReference<Thread> edit, int shift, int hash, TKey key, Box<object> removedLeaf)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0)
            {
                return this;
            }

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];

            if (!keyOrNull.HasValue)
            {
                var n = valOrNode.Item3.Without(edit, shift + 5, hash, key, removedLeaf);

                if (n == valOrNode)
                {
                    return this;
                }

                if (n != null)
                {
                    return EditAndSet(edit, 2 * idx + 1, UnionType<TKey, TValue, INode<TKey, TValue>>.Create(n));
                }

                if (this._bitmap == bit)
                {
                    return null;
                }

                return EditAndRemovePair(edit, bit, idx);
            }

            if (key == keyOrNull)
            {
                removedLeaf.Value = removedLeaf;
                return EditAndRemovePair(edit, bit, idx);
            }

            return this;
        }

        BitmapIndexedNode<TKey, TValue> EnsureEditable(AtomicReference<Thread> edit)
        {
            if (this._edit == edit)
            {
                return this;
            }

            int n = BitCount(this._bitmap);
            var newArray = new UnionType<TKey, TValue, INode<TKey, TValue>>[n >= 0 ? 2 * (n + 1) : 4]; // make room for the next assoc
            System.Array.Copy(this._array, newArray, 2 * n);
            return new BitmapIndexedNode<TKey, TValue>(edit, this._bitmap, newArray);
        }

        BitmapIndexedNode<TKey, TValue> EditAndSet(AtomicReference<Thread> edit, int i, UnionType<TKey, TValue, INode<TKey, TValue>> a)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            return editable;
        }

        BitmapIndexedNode<TKey, TValue> EditAndSet(AtomicReference<Thread> edit, int i, UnionType<TKey, TValue, INode<TKey, TValue>> a, int j, UnionType<TKey, TValue, INode<TKey, TValue>> b)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            editable._array[j] = b;
            return editable;
        }

        BitmapIndexedNode<TKey, TValue> EditAndRemovePair(AtomicReference<Thread> edit, int bit, int i)
        {
            if (this._bitmap == bit)
            {
                return null;
            }

            var editable = EnsureEditable(edit);
            editable._bitmap ^= bit;
            System.Array.Copy(editable._array, 2 * (i + 1), editable._array, 2 * i, editable._array.Length - 2 * (i + 1));
            editable._array[editable._array.Length - 2] = null;
            editable._array[editable._array.Length - 1] = null;
            return editable;
        }
    }
}