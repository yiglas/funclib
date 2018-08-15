namespace funclib.Collections
{
    public sealed class ChunkBuffer :
        ICounted
    {
        object[] _buffer;
        int _end;

        public ChunkBuffer(int capacity)
        {
            this._buffer = new object[capacity];
            this._end = 0;
        }

        public ChunkBuffer Add(object o)
        {
            this._buffer[this._end++] = o;
            return this;
        }
        public IChunked Chunk()
        {
            var ret = new ArrayChunked(this._buffer, 0, this._end);
            this._buffer = null;
            return ret;
        }

        public int Count => this._end;
    }
}
