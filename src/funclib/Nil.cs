namespace funclib
{
    public struct Nil
    {
        public override string ToString()
        {
            return "null";
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Nil || obj is null)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Nil nil, object o)
        {
            return o is null;
        }

        public static bool operator !=(Nil nil, object o)
        {
            return !(nil == o);
        }

        public static bool operator ==(object o, Nil nil)
        {
            return nil == o;
        }

        public static bool operator !=(object o, Nil nil)
        {
            return !(nil == o);
        }
    }
}
