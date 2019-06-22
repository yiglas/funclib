namespace funclib
{

    public struct UnionType<T1, T2>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;

        UnionType(int i, T1 v1 = default, T2 v2 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
            }

            return false;
        }

        public static UnionType<T1, T2> Create(T1 item) => new UnionType<T1, T2>(1, v1: item);
        public static UnionType<T1, T2> Create(T2 item) => new UnionType<T1, T2>(2, v2: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2> u) => u == t;
        public static bool operator !=(UnionType<T1, T2> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2> u) => u == t;
        public static bool operator !=(UnionType<T1, T2> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
            }

            return false;
        }

        public static UnionType<T1, T2, T3> Create(T1 item) => new UnionType<T1, T2, T3>(1, v1: item);
        public static UnionType<T1, T2, T3> Create(T2 item) => new UnionType<T1, T2, T3>(2, v2: item);
        public static UnionType<T1, T2, T3> Create(T3 item) => new UnionType<T1, T2, T3>(3, v3: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4> Create(T1 item) => new UnionType<T1, T2, T3, T4>(1, v1: item);
        public static UnionType<T1, T2, T3, T4> Create(T2 item) => new UnionType<T1, T2, T3, T4>(2, v2: item);
        public static UnionType<T1, T2, T3, T4> Create(T3 item) => new UnionType<T1, T2, T3, T4>(3, v3: item);
        public static UnionType<T1, T2, T3, T4> Create(T4 item) => new UnionType<T1, T2, T3, T4>(4, v4: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5>(5, v5: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6>(6, v6: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7>(7, v7: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(8, v8: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(9, v9: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(10, v10: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(11, v11: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;
        readonly T12 _v12;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default, T12 v12 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
            this._v12 = v12;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
                case 12: return this._v12?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
                case 12: return this._v12?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
                case 12: return Equals(this._v12, u._v12);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(11, v11: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(T12 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(12, v12: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);

        public bool IsItem12 => this._i == 12;
        public T12 Item12 => this._v12;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T12 t) => Create(t);
        public static implicit operator T12(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u._v12;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T12 t) => u.Item12.Equals(t);
        public static bool operator ==(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u, T12 t) => !(t == u);
        public static bool operator !=(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;
        readonly T12 _v12;
        readonly T13 _v13;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default, T12 v12 = default, T13 v13 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
            this._v12 = v12;
            this._v13 = v13;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
                case 12: return this._v12?.GetHashCode() ?? 0;
                case 13: return this._v13?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
                case 12: return this._v12?.ToString() ?? "";
                case 13: return this._v13?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
                case 12: return Equals(this._v12, u._v12);
                case 13: return Equals(this._v13, u._v13);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(11, v11: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T12 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(12, v12: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(T13 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(13, v13: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem12 => this._i == 12;
        public T12 Item12 => this._v12;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 t) => Create(t);
        public static implicit operator T12(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v12;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T12 t) => u.Item12.Equals(t);
        public static bool operator ==(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T12 t) => !(t == u);
        public static bool operator !=(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);

        public bool IsItem13 => this._i == 13;
        public T13 Item13 => this._v13;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 t) => Create(t);
        public static implicit operator T13(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u._v13;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T13 t) => u.Item13.Equals(t);
        public static bool operator ==(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u, T13 t) => !(t == u);
        public static bool operator !=(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;
        readonly T12 _v12;
        readonly T13 _v13;
        readonly T14 _v14;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default, T12 v12 = default, T13 v13 = default, T14 v14 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
            this._v12 = v12;
            this._v13 = v13;
            this._v14 = v14;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
                case 12: return this._v12?.GetHashCode() ?? 0;
                case 13: return this._v13?.GetHashCode() ?? 0;
                case 14: return this._v14?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
                case 12: return this._v12?.ToString() ?? "";
                case 13: return this._v13?.ToString() ?? "";
                case 14: return this._v14?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
                case 12: return Equals(this._v12, u._v12);
                case 13: return Equals(this._v13, u._v13);
                case 14: return Equals(this._v14, u._v14);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(11, v11: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T12 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(12, v12: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T13 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(13, v13: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(T14 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(14, v14: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem12 => this._i == 12;
        public T12 Item12 => this._v12;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T12 t) => Create(t);
        public static implicit operator T12(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v12;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T12 t) => u.Item12.Equals(t);
        public static bool operator ==(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T12 t) => !(t == u);
        public static bool operator !=(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem13 => this._i == 13;
        public T13 Item13 => this._v13;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T13 t) => Create(t);
        public static implicit operator T13(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v13;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T13 t) => u.Item13.Equals(t);
        public static bool operator ==(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T13 t) => !(t == u);
        public static bool operator !=(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);

        public bool IsItem14 => this._i == 14;
        public T14 Item14 => this._v14;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T14 t) => Create(t);
        public static implicit operator T14(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u._v14;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T14 t) => u.Item14.Equals(t);
        public static bool operator ==(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u, T14 t) => !(t == u);
        public static bool operator !=(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;
        readonly T12 _v12;
        readonly T13 _v13;
        readonly T14 _v14;
        readonly T15 _v15;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default, T12 v12 = default, T13 v13 = default, T14 v14 = default, T15 v15 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
            this._v12 = v12;
            this._v13 = v13;
            this._v14 = v14;
            this._v15 = v15;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
                case 12: return this._v12?.GetHashCode() ?? 0;
                case 13: return this._v13?.GetHashCode() ?? 0;
                case 14: return this._v14?.GetHashCode() ?? 0;
                case 15: return this._v15?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
                case 12: return this._v12?.ToString() ?? "";
                case 13: return this._v13?.ToString() ?? "";
                case 14: return this._v14?.ToString() ?? "";
                case 15: return this._v15?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
                case 12: return Equals(this._v12, u._v12);
                case 13: return Equals(this._v13, u._v13);
                case 14: return Equals(this._v14, u._v14);
                case 15: return Equals(this._v15, u._v15);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(11, v11: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T12 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(12, v12: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T13 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(13, v13: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T14 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(14, v14: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create(T15 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(15, v15: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem12 => this._i == 12;
        public T12 Item12 => this._v12;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T12 t) => Create(t);
        public static implicit operator T12(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v12;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T12 t) => u.Item12.Equals(t);
        public static bool operator ==(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T12 t) => !(t == u);
        public static bool operator !=(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem13 => this._i == 13;
        public T13 Item13 => this._v13;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T13 t) => Create(t);
        public static implicit operator T13(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v13;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T13 t) => u.Item13.Equals(t);
        public static bool operator ==(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T13 t) => !(t == u);
        public static bool operator !=(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem14 => this._i == 14;
        public T14 Item14 => this._v14;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T14 t) => Create(t);
        public static implicit operator T14(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v14;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T14 t) => u.Item14.Equals(t);
        public static bool operator ==(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T14 t) => !(t == u);
        public static bool operator !=(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);

        public bool IsItem15 => this._i == 15;
        public T15 Item15 => this._v15;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T15 t) => Create(t);
        public static implicit operator T15(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u._v15;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T15 t) => u.Item15.Equals(t);
        public static bool operator ==(T15 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u, T15 t) => !(t == u);
        public static bool operator !=(T15 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;
        readonly T12 _v12;
        readonly T13 _v13;
        readonly T14 _v14;
        readonly T15 _v15;
        readonly T16 _v16;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default, T12 v12 = default, T13 v13 = default, T14 v14 = default, T15 v15 = default, T16 v16 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
            this._v12 = v12;
            this._v13 = v13;
            this._v14 = v14;
            this._v15 = v15;
            this._v16 = v16;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
                case 12: return this._v12?.GetHashCode() ?? 0;
                case 13: return this._v13?.GetHashCode() ?? 0;
                case 14: return this._v14?.GetHashCode() ?? 0;
                case 15: return this._v15?.GetHashCode() ?? 0;
                case 16: return this._v16?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
                case 12: return this._v12?.ToString() ?? "";
                case 13: return this._v13?.ToString() ?? "";
                case 14: return this._v14?.ToString() ?? "";
                case 15: return this._v15?.ToString() ?? "";
                case 16: return this._v16?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
                case 12: return Equals(this._v12, u._v12);
                case 13: return Equals(this._v13, u._v13);
                case 14: return Equals(this._v14, u._v14);
                case 15: return Equals(this._v15, u._v15);
                case 16: return Equals(this._v16, u._v16);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(11, v11: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T12 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(12, v12: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T13 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(13, v13: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T14 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(14, v14: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T15 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(15, v15: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create(T16 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(16, v16: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem12 => this._i == 12;
        public T12 Item12 => this._v12;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T12 t) => Create(t);
        public static implicit operator T12(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v12;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T12 t) => u.Item12.Equals(t);
        public static bool operator ==(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T12 t) => !(t == u);
        public static bool operator !=(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem13 => this._i == 13;
        public T13 Item13 => this._v13;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T13 t) => Create(t);
        public static implicit operator T13(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v13;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T13 t) => u.Item13.Equals(t);
        public static bool operator ==(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T13 t) => !(t == u);
        public static bool operator !=(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem14 => this._i == 14;
        public T14 Item14 => this._v14;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T14 t) => Create(t);
        public static implicit operator T14(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v14;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T14 t) => u.Item14.Equals(t);
        public static bool operator ==(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T14 t) => !(t == u);
        public static bool operator !=(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem15 => this._i == 15;
        public T15 Item15 => this._v15;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T15 t) => Create(t);
        public static implicit operator T15(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v15;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T15 t) => u.Item15.Equals(t);
        public static bool operator ==(T15 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T15 t) => !(t == u);
        public static bool operator !=(T15 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);

        public bool IsItem16 => this._i == 16;
        public T16 Item16 => this._v16;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T16 t) => Create(t);
        public static implicit operator T16(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u._v16;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T16 t) => u.Item16.Equals(t);
        public static bool operator ==(T16 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u, T16 t) => !(t == u);
        public static bool operator !=(T16 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> u) => !(t == u);
    }

    public struct UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>
    {
        readonly int _i;
        readonly T1 _v1;
        readonly T2 _v2;
        readonly T3 _v3;
        readonly T4 _v4;
        readonly T5 _v5;
        readonly T6 _v6;
        readonly T7 _v7;
        readonly T8 _v8;
        readonly T9 _v9;
        readonly T10 _v10;
        readonly T11 _v11;
        readonly T12 _v12;
        readonly T13 _v13;
        readonly T14 _v14;
        readonly T15 _v15;
        readonly T16 _v16;
        readonly T17 _v17;

        UnionType(int i, T1 v1 = default, T2 v2 = default, T3 v3 = default, T4 v4 = default, T5 v5 = default, T6 v6 = default, T7 v7 = default, T8 v8 = default, T9 v9 = default, T10 v10 = default, T11 v11 = default, T12 v12 = default, T13 v13 = default, T14 v14 = default, T15 v15 = default, T16 v16 = default, T17 v17 = default)
        {
            this._i = i;
            this._v1 = v1;
            this._v2 = v2;
            this._v3 = v3;
            this._v4 = v4;
            this._v5 = v5;
            this._v6 = v6;
            this._v7 = v7;
            this._v8 = v8;
            this._v9 = v9;
            this._v10 = v10;
            this._v11 = v11;
            this._v12 = v12;
            this._v13 = v13;
            this._v14 = v14;
            this._v15 = v15;
            this._v16 = v16;
            this._v17 = v17;
        }

        #region Overrides
        public override int GetHashCode()
        {
            switch (this._i)
            {
                case 1: return this._v1?.GetHashCode() ?? 0;
                case 2: return this._v2?.GetHashCode() ?? 0;
                case 3: return this._v3?.GetHashCode() ?? 0;
                case 4: return this._v4?.GetHashCode() ?? 0;
                case 5: return this._v5?.GetHashCode() ?? 0;
                case 6: return this._v6?.GetHashCode() ?? 0;
                case 7: return this._v7?.GetHashCode() ?? 0;
                case 8: return this._v8?.GetHashCode() ?? 0;
                case 9: return this._v9?.GetHashCode() ?? 0;
                case 10: return this._v10?.GetHashCode() ?? 0;
                case 11: return this._v11?.GetHashCode() ?? 0;
                case 12: return this._v12?.GetHashCode() ?? 0;
                case 13: return this._v13?.GetHashCode() ?? 0;
                case 14: return this._v14?.GetHashCode() ?? 0;
                case 15: return this._v15?.GetHashCode() ?? 0;
                case 16: return this._v16?.GetHashCode() ?? 0;
                case 17: return this._v17?.GetHashCode() ?? 0;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u && Equals(u);
        }

        public override string ToString()
        {
            switch (this._i)
            {
                case 1: return this._v1?.ToString() ?? "";
                case 2: return this._v2?.ToString() ?? "";
                case 3: return this._v3?.ToString() ?? "";
                case 4: return this._v4?.ToString() ?? "";
                case 5: return this._v5?.ToString() ?? "";
                case 6: return this._v6?.ToString() ?? "";
                case 7: return this._v7?.ToString() ?? "";
                case 8: return this._v8?.ToString() ?? "";
                case 9: return this._v9?.ToString() ?? "";
                case 10: return this._v10?.ToString() ?? "";
                case 11: return this._v11?.ToString() ?? "";
                case 12: return this._v12?.ToString() ?? "";
                case 13: return this._v13?.ToString() ?? "";
                case 14: return this._v14?.ToString() ?? "";
                case 15: return this._v15?.ToString() ?? "";
                case 16: return this._v16?.ToString() ?? "";
                case 17: return this._v17?.ToString() ?? "";
            }

            return "";
        }
        #endregion

        public bool Equals(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u)
        {
            if (this._i != u._i)
            {
                return false;
            }

            switch (this._i)
            {
                case 1: return Equals(this._v1, u._v1);
                case 2: return Equals(this._v2, u._v2);
                case 3: return Equals(this._v3, u._v3);
                case 4: return Equals(this._v4, u._v4);
                case 5: return Equals(this._v5, u._v5);
                case 6: return Equals(this._v6, u._v6);
                case 7: return Equals(this._v7, u._v7);
                case 8: return Equals(this._v8, u._v8);
                case 9: return Equals(this._v9, u._v9);
                case 10: return Equals(this._v10, u._v10);
                case 11: return Equals(this._v11, u._v11);
                case 12: return Equals(this._v12, u._v12);
                case 13: return Equals(this._v13, u._v13);
                case 14: return Equals(this._v14, u._v14);
                case 15: return Equals(this._v15, u._v15);
                case 16: return Equals(this._v16, u._v16);
                case 17: return Equals(this._v17, u._v17);
            }

            return false;
        }

        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T1 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(1, v1: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T2 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(2, v2: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T3 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(3, v3: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T4 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(4, v4: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T5 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(5, v5: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T6 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(6, v6: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T7 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(7, v7: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T8 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(8, v8: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T9 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(9, v9: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T10 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(10, v10: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T11 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(11, v11: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T12 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(12, v12: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T13 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(13, v13: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T14 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(14, v14: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T15 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(15, v15: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T16 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(16, v16: item);
        public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create(T17 item) => new UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(17, v17: item);

        public bool HasValue => this._i > 0;

        public bool IsItem1 => this._i == 1;
        public T1 Item1 => this._v1;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 t) => Create(t);
        public static implicit operator T1(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v1;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T1 t) => u.Item1.Equals(t);
        public static bool operator ==(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T1 t) => !(t == u);
        public static bool operator !=(T1 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem2 => this._i == 2;
        public T2 Item2 => this._v2;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T2 t) => Create(t);
        public static implicit operator T2(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v2;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T2 t) => u.Item2.Equals(t);
        public static bool operator ==(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T2 t) => !(t == u);
        public static bool operator !=(T2 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem3 => this._i == 3;
        public T3 Item3 => this._v3;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T3 t) => Create(t);
        public static implicit operator T3(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v3;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T3 t) => u.Item3.Equals(t);
        public static bool operator ==(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T3 t) => !(t == u);
        public static bool operator !=(T3 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem4 => this._i == 4;
        public T4 Item4 => this._v4;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T4 t) => Create(t);
        public static implicit operator T4(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v4;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T4 t) => u.Item4.Equals(t);
        public static bool operator ==(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T4 t) => !(t == u);
        public static bool operator !=(T4 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem5 => this._i == 5;
        public T5 Item5 => this._v5;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T5 t) => Create(t);
        public static implicit operator T5(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v5;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T5 t) => u.Item5.Equals(t);
        public static bool operator ==(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T5 t) => !(t == u);
        public static bool operator !=(T5 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem6 => this._i == 6;
        public T6 Item6 => this._v6;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T6 t) => Create(t);
        public static implicit operator T6(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v6;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T6 t) => u.Item6.Equals(t);
        public static bool operator ==(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T6 t) => !(t == u);
        public static bool operator !=(T6 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem7 => this._i == 7;
        public T7 Item7 => this._v7;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T7 t) => Create(t);
        public static implicit operator T7(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v7;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T7 t) => u.Item7.Equals(t);
        public static bool operator ==(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T7 t) => !(t == u);
        public static bool operator !=(T7 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem8 => this._i == 8;
        public T8 Item8 => this._v8;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T8 t) => Create(t);
        public static implicit operator T8(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v8;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T8 t) => u.Item8.Equals(t);
        public static bool operator ==(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T8 t) => !(t == u);
        public static bool operator !=(T8 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem9 => this._i == 9;
        public T9 Item9 => this._v9;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T9 t) => Create(t);
        public static implicit operator T9(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v9;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T9 t) => u.Item9.Equals(t);
        public static bool operator ==(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T9 t) => !(t == u);
        public static bool operator !=(T9 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem10 => this._i == 10;
        public T10 Item10 => this._v10;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T10 t) => Create(t);
        public static implicit operator T10(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v10;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T10 t) => u.Item10.Equals(t);
        public static bool operator ==(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T10 t) => !(t == u);
        public static bool operator !=(T10 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem11 => this._i == 11;
        public T11 Item11 => this._v11;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T11 t) => Create(t);
        public static implicit operator T11(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v11;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T11 t) => u.Item11.Equals(t);
        public static bool operator ==(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T11 t) => !(t == u);
        public static bool operator !=(T11 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem12 => this._i == 12;
        public T12 Item12 => this._v12;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T12 t) => Create(t);
        public static implicit operator T12(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v12;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T12 t) => u.Item12.Equals(t);
        public static bool operator ==(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T12 t) => !(t == u);
        public static bool operator !=(T12 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem13 => this._i == 13;
        public T13 Item13 => this._v13;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T13 t) => Create(t);
        public static implicit operator T13(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v13;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T13 t) => u.Item13.Equals(t);
        public static bool operator ==(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T13 t) => !(t == u);
        public static bool operator !=(T13 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem14 => this._i == 14;
        public T14 Item14 => this._v14;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T14 t) => Create(t);
        public static implicit operator T14(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v14;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T14 t) => u.Item14.Equals(t);
        public static bool operator ==(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T14 t) => !(t == u);
        public static bool operator !=(T14 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem15 => this._i == 15;
        public T15 Item15 => this._v15;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T15 t) => Create(t);
        public static implicit operator T15(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v15;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T15 t) => u.Item15.Equals(t);
        public static bool operator ==(T15 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T15 t) => !(t == u);
        public static bool operator !=(T15 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem16 => this._i == 16;
        public T16 Item16 => this._v16;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T16 t) => Create(t);
        public static implicit operator T16(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v16;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T16 t) => u.Item16.Equals(t);
        public static bool operator ==(T16 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T16 t) => !(t == u);
        public static bool operator !=(T16 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);

        public bool IsItem17 => this._i == 17;
        public T17 Item17 => this._v17;
        public static implicit operator UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T17 t) => Create(t);
        public static implicit operator T17(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u._v17;
        public static bool operator ==(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T17 t) => u.Item17.Equals(t);
        public static bool operator ==(T17 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => u == t;
        public static bool operator !=(UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u, T17 t) => !(t == u);
        public static bool operator !=(T17 t, UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> u) => !(t == u);
    }
}