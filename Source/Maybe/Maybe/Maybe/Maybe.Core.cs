namespace System
{
    public static partial class Maybe
    {
        public static Option<T> HasValue<T>(T value)
            where T: class
        {
            if (value == null) return Option.None<T>();

            return Option.Some(value);
        }
    }
}
