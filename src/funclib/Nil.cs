using System.Runtime.CompilerServices;

namespace funclib
{
    public struct Nil
    {
        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override bool Equals(object obj) => obj == this;

        public override string ToString() => "nil";

        public static bool operator ==(object obj, Nil nil)
        {
            if (obj is null)
            {
                return true;
            }

            if (obj is Nil)
            {
                return true;
            }


             return false;
        }
        public static bool operator !=(object obj, Nil nil) => !(obj == nil);
        public static bool operator ==(Nil nil, object obj) => obj == nil;
        public static bool operator !=(Nil nil, object obj) => !(obj == nil);
        public static bool operator ==(Nil n1, Nil n2) => true;
        public static bool operator !=(Nil n1, Nil n2) => false;
    }
}