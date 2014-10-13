namespace System
{
    /// <summary>
    /// Provides a set of static methods for querying objects that <see cref="System.Option{T}"/>.
    /// </summary>
    public static partial class Maybe
    {
        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> that represents a value.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <param name="value">
        /// A value.
        /// </param>
        /// <returns>
        /// Some value that represents a <paramref name="value"/> if <paramref name="value"/> is not
        /// null; otherwise, None value.
        /// </returns>
        public static Option<T> HasValue<T>(T value)
            where T: class
        {
            if (value == null) return Option.None<T>();

            return Option.Some(value);
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> that represents a value.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <param name="value">
        /// A nullable value.
        /// </param>
        /// <returns>
        /// Some value that represents a <paramref name="value"/> if <paramref name="value"/> is not
        /// null; otherwise, None value.
        /// </returns>
        public static Option<T> HasValue<T>(Nullable<T> value)
            where T : struct
        {
            if (value.HasValue) return Option.Some(value.Value);

            return Option.None<T>();
        }

        /// <summary>
        /// Returns an <see cref="System.Nullable{T}"/> that represents a value.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Nullable{T}"/> generic type.
        /// </typeparam>
        /// <param name="option">
        /// A optional value.
        /// </param>
        /// <returns>
        /// A <see cref="System.Nullable{T}"/> value that contains a <paramref name="option"/>
        /// value if <paramref name="option"/> is Some; otherwise, null.
        /// </returns>
        public static Nullable<T> ToNullable<T>(this Option<T> option)
            where T : struct
        {
            if (option.HasValue) return new Nullable<T>(option.Value);

            return new Nullable<T>();
        }
    }
}
