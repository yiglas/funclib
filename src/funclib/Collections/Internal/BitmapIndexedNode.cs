using System;
using System.Text;
using System.Threading;
using funclib.Components.Core;
using static funclib.Util;

namespace funclib.Collections.Internal
{
    [Serializable]
    sealed class BitmapIndexedNode :
        INode
    {
        public static readonly BitmapIndexedNode EMPTY = new BitmapIndexedNode(null, 0, new object[0]);

        int _bitmap;
        object[] _array;

        [NonSerialized]
        readonly AtomicReference<Thread> _edit;

        int Index(int bit) => BitCount(this._bitmap & (bit - 1));

        public BitmapIndexedNode(AtomicReference<Thread> edit, int bitmap, object[] array)
        {
            this._bitmap = bitmap;
            this._array = array;
            this._edit = edit;
        }

        public INode Assoc(int shift, int hash, object key, object val, Box addedLeaf)
        {
            int bit = Bitpos(hash, shift);
            int idx = Index(bit);
            if ((this._bitmap & bit) != 0)
            {
                var keyOrNull = this._array[2 * idx];
                var valOrNode = this._array[2 * idx + 1];

                if (keyOrNull == null)
                {
                    var n = ((INode)valOrNode).Assoc(shift + 5, hash, key, val, addedLeaf);
                    if (n == valOrNode)
                        return this;

                    return new BitmapIndexedNode(null, this._bitmap, CloneAndSet(this._array, 2 * idx + 1, n));
                }

                if ((bool)new IsEqual().Invoke(key, keyOrNull))
                {
                    if (val == valOrNode)
                        return this;

                    return new BitmapIndexedNode(null, this._bitmap, CloneAndSet(this._array, 2 * idx + 1, val));
                }

                addedLeaf.Value = addedLeaf;

                return new BitmapIndexedNode(null, this._bitmap,
                    CloneAndSet(this._array,
                                2 * idx,
                                null,
                                2 * idx + 1,
                                CreateNode(shift + 5, keyOrNull, valOrNode, hash, key, val)));
            }
            else
            {
                int n = BitCount(this._bitmap);
                if (n >= 16)
                {
                    var nodes = new INode[32];
                    int jdx = Mask(hash, shift);
                    nodes[jdx] = EMPTY.Assoc(shift + 5, hash, key, val, addedLeaf);
                    int j = 0;
                    for (int i = 0; i < 32; i++)
                    {
                        if (((this._bitmap >> i) & 1) != 0)
                        {
                            if (this._array[j] == null)
                                nodes[i] = this._array[j + 1] as INode;
                            else
                                nodes[i] = EMPTY.Assoc(shift + 5, GetHash(this._array[j]), this._array[j], this._array[j + 1], addedLeaf);
                            j += 2;
                        }
                    }

                    return new ArrayNode(null, n + 1, nodes);
                }
                else
                {
                    var newArray = new object[2 * (n + 1)];
                    System.Array.Copy(this._array, 0, newArray, 0, 2 * idx);
                    newArray[2 * idx] = key;
                    addedLeaf.Value = addedLeaf;
                    newArray[2 * idx + 1] = val;
                    System.Array.Copy(this._array, 2 * idx, newArray, 2 * (idx + 1), 2 * (n - idx));

                    return new BitmapIndexedNode(null, this._bitmap | bit, newArray);
                }
            }
        }

        public INode Assoc(AtomicReference<Thread> edit, int shift, int hash, object key, object val, Box addedLeaf)
        {
            int bit = Bitpos(hash, shift);
            int idx = Index(bit);
            if ((this._bitmap & bit) != 0)
            {
                var keyOrNull = this._array[2 * idx];
                var valOrNode = this._array[2 * idx + 1];
                
                if (keyOrNull == null)
                {
                    var n = ((INode)valOrNode).Assoc(edit, shift + 5, hash, key, val, addedLeaf);
                    if (n == valOrNode) return this;
                    return EditAndSet(edit, 2 * idx + 1, n);
                }
                if ((bool)new IsEqual().Invoke(key, keyOrNull))
                {
                    if (val == valOrNode) return this;
                    return EditAndSet(edit, 2 * idx + 1, val);
                }
                addedLeaf.Value = addedLeaf;
                return EditAndSet(edit,
                    2 * idx,
                    null,
                    2 * idx + 1,
                    CreateNode(edit, shift + 5, keyOrNull, valOrNode, hash, key, val));
            }
            else
            {
                int n = BitCount(this._bitmap);
                if (n * 2 < this._array.Length)
                {
                    addedLeaf.Value = addedLeaf;
                    var editable = EnsureEditable(edit);
                    System.Array.Copy(editable._array, 2 * idx, editable._array, 2 * (idx + 1), 2 * (n - idx));
                    editable._array[2 * idx] = key;
                    editable._array[2 * idx + 1] = val;
                    editable._bitmap |= bit;
                    return editable;
                }

                if (n >= 16)
                {
                    var nodes = new INode[32];
                    int jdx = Mask(hash, shift);
                    nodes[jdx] = EMPTY.Assoc(edit, shift + 5, hash, key, val, addedLeaf);
                    int j = 0;
                    for (int i = 0; i < 32; i++)
                    {
                        if (((this._bitmap >> i) & 1) != 0)
                        {
                            if (this._array[j] == null)
                            {
                                nodes[i] = this._array[j + 1] as INode;
                            }
                            else
                                nodes[i] = EMPTY.Assoc(edit, shift + 5, GetHash(this._array[j]), this._array[j], this._array[j + 1], addedLeaf);

                            j += 2;
                        }
                    }

                    return new ArrayNode(edit, n + 1, nodes);
                }
                else
                {
                    var newArray = new object[2 * (n + 4)];
                    System.Array.Copy(this._array, 0, newArray, 0, 2 * idx);
                    newArray[2 * idx] = key;
                    addedLeaf.Value = addedLeaf;
                    newArray[2 * idx + 1] = val;
                    System.Array.Copy(this._array, 2 * idx, newArray, 2 * (idx + 1), 2 * (n - idx));
                    var editable = EnsureEditable(edit);
                    editable._array = newArray;
                    editable._bitmap |= bit;
                    return editable;
                }
            }
        }

        public INode Without(int shift, int hash, object key)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0) return this;

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];
            if (keyOrNull == null)
            {
                var n = ((INode)valOrNode).Without(shift + 5, hash, key);

                if (n == valOrNode) return this;
                if (n != null) return new BitmapIndexedNode(null, this._bitmap, CloneAndSet(this._array, 2 * idx + 1, n));
                if (this._bitmap == bit) return null;

                return new BitmapIndexedNode(null, this._bitmap ^ bit, RemovePair(this._array, idx));
            }

            if ((bool)new IsEqual().Invoke(key, keyOrNull))
            {
                return new BitmapIndexedNode(null, this._bitmap ^ bit, RemovePair(this._array, idx));
            }

            return this;
        }

        public INode Without(AtomicReference<Thread> edit, int shift, int hash, object key, Box removedLeaf)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0) return this;

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];
            if (keyOrNull == null)
            {
                var n = ((INode)valOrNode).Without(edit, shift + 5, hash, key, removedLeaf);

                if (n == valOrNode) return this;
                if (n != null) return EditAndSet(edit, 2 * idx + 1, n);
                if (this._bitmap == bit) return null;

                return EditAndRemovePair(edit, bit, idx);
            }

            if ((bool)new IsEqual().Invoke(key, keyOrNull))
            {
                removedLeaf.Value = removedLeaf;
                return EditAndRemovePair(edit, bit, idx);
            }

            return this;
        }

        public IKeyValuePair Get(int shift, int hash, object key)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0) return null;

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];

            if (keyOrNull == null)
                return ((INode)valOrNode).Get(shift + 5, hash, key);
            if ((bool)new IsEqual().Invoke(key, keyOrNull))
                return new KeyValuePair(keyOrNull, valOrNode);

            return null;
        }

        public object Get(int shift, int hash, object key, object notFound)
        {
            int bit = Bitpos(hash, shift);
            if ((this._bitmap & bit) == 0) return notFound;

            int idx = Index(bit);
            var keyOrNull = this._array[2 * idx];
            var valOrNode = this._array[2 * idx + 1];

            if (keyOrNull == null)
                return ((INode)valOrNode).Get(shift + 5, hash, key, notFound);
            if ((bool)new IsEqual().Invoke(key, keyOrNull))
                return valOrNode;

            return notFound;
        }

        public ISeq GetNodeEnumerative() => NodeSeq.Create(this._array);
        public System.Collections.IEnumerator GetEnumerator(Func<object, object, object> d)
        {
            for (int i = 0; i < this._array.Length; i += 2)
            {
                var key = this._array[i];
                var nodeOrVal = this._array[i + 1];

                if (key != null) yield return d(key, nodeOrVal);
                else if (nodeOrVal != null)
                {
                    var ie = ((INode)nodeOrVal).GetEnumerator(d);
                    while (ie.MoveNext())
                        yield return ie.Current;
                }
            }
        }

        BitmapIndexedNode EnsureEditable(AtomicReference<Thread> edit)
        {
            if (this._edit == edit) return this;
            int n = BitCount(this._bitmap);
            var newArray = new object[n >= 0 ? 2 * (n + 1) : 4]; // make room for the next assoc
            System.Array.Copy(this._array, newArray, 2 * n);
            return new BitmapIndexedNode(edit, this._bitmap, newArray);
        }

        BitmapIndexedNode EditAndSet(AtomicReference<Thread> edit, int i, object a)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            return editable;
        }

        BitmapIndexedNode EditAndSet(AtomicReference<Thread> edit, int i, object a, int j, object b)
        {
            var editable = EnsureEditable(edit);
            editable._array[i] = a;
            editable._array[j] = b;
            return editable;
        }

        BitmapIndexedNode EditAndRemovePair(AtomicReference<Thread> edit, int bit, int i)
        {
            if (this._bitmap == bit) return null;
            var editable = EnsureEditable(edit);
            editable._bitmap ^= bit;
            System.Array.Copy(editable._array, 2 * (i + 1), editable._array, 2 * i, editable._array.Length - 2 * (i + 1));
            editable._array[editable._array.Length - 2] = null;
            editable._array[editable._array.Length - 1] = null;
            return editable;
        }

        public object Reduce(IFunction f, object init) => NodeSeq.Reduce(this._array, f, init);
    }
}
