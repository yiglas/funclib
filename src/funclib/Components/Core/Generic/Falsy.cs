namespace funclib.Components.Core.Generic
{
    public static partial class Stuff
    {
        public static bool Falsy(bool source) => !source;
        public static bool Falsy<T>(T source)
        {
            if (source == null)
            {
                return true;
            }

            return true;
        }
    }
}
