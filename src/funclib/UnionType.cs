using System;

namespace funclib
{
    public struct UnionType<T1, T2>
    {
        readonly T1 _v0;
        readonly T2 _v1;
        readonly int _i;

        UnionType(int i, T1 v0 = default, T2 v1 = default)
        {
            this._i = i;
            this._v0 = v0;
            this._v1 = v1;
        }

        public static UnionType<T1, T2> Create(T1 item) => new UnionType<T1, T2>(1, v0: item);
        public static UnionType<T1, T2> Create(T2 item) => new UnionType<T1, T2>(2, v1: item);

        public bool HasValue => this._i != 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v0;
        public static implicit operator UnionType<T1, T2>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2> u) => u._v0;

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v1;
        public static implicit operator UnionType<T1, T2>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2> u) => u._v1;

        public override string ToString()
        {
            if (!HasValue)
            {
                return "Not set";
            }
            
            if (IsItem1)
            {
                return Item1.ToString();
            }

            return Item2.ToString();
        }
    }
}
