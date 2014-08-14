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

        public static Option<T> HasValue<T>(Nullable<T> value)
            where T : struct
        {
            if (value.HasValue) return Option.Some(value.Value);

            return Option.None<T>();
        }

        public static Nullable<T> ToNullable<T>(this Option<T> option)
            where T : struct
        {
            if (option.HasValue) return new Nullable<T>(option.Value);

            return new Nullable<T>();
        }
    }
}
