namespace System
{
    /// <summary>
    /// Represents the optional values.
    /// </summary>
    /// <typeparam name="T">
    /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
    /// </typeparam>
    public struct Option<T> : IEquatable<Option<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Option{T}"/> structure.
        /// </summary>
        /// <param name="value">
        /// A value.
        /// </param>
        /// <param name="hasValue">
        /// true if this object has a value; false if this object has not a value.
        /// </param>
        internal Option(T value, bool hasValue)
        {
            _Value = value;
            _HasValue = hasValue;
        }

        private readonly T _Value;

        /// <summary>
        /// Gets the value of the current <see cref="System.Option{T}"/> object if it has been
        /// assigned a valid underlying value.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The HasValue property is false.
        /// </exception>
        public T Value
        {
            get
            {
                if (!HasValue) throw new InvalidOperationException("Option object must have a value.");

                return _Value;
            }
        }

        private readonly bool _HasValue;

        /// <summary>
        /// Gets a value indicating whether the current <see cref="System.Option{T}"/> object has a
        /// valid value of its underlying type. 
        /// </summary>
        public bool HasValue
        {
            get { return _HasValue; }
        }

        /// <summary>
        /// Returns the text representation of the value of the current
        /// <see cref="System.Option{T}"/> object.
        /// </summary>
        /// <returns>
        /// The text representation of the value of the current <see cref="System.Option{T}"/>
        /// object if the HasValue property is true, or a string indicating that the object has not
        /// a value if the HasValue property is false.
        /// </returns>
        public override string ToString()
        {
            if (HasValue) return string.Format("Some({0})", Value);
            else return "None";
        }

        /// <summary>
        /// Indicates whether the current <see cref="System.Option{T}"/> object is equal to a
        /// specified object.
        /// </summary>
        /// <param name="other">
        /// An object to compare with this object.
        /// </param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        /// <summary>
        /// Retrieves the hash code of the object returned by the Value property.
        /// </summary>
        /// <returns>
        /// The hash code of the object returned by the Value property if the HasValue property is
        /// true, or zero if the HasValue property is false.
        /// </returns>
        public override int GetHashCode()
        {
            if (HasValue)
            {
                return Value.GetHashCode();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="System.Option{T}"/> are equal.
        /// </summary>
        /// <param name="option1">
        /// The first object to compare.
        /// </param>
        /// <param name="option2">
        /// The second object to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="option1"/> and <paramref name="option2"/> represent the same
        /// <see cref="System.Option{T}"/> object; otherwise, false.
        /// </returns>
        public static bool operator ==(Option<T> option1, Option<T> option2)
        {
            return option1.Equals(option2);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="System.Option{T}"/> are not
        /// equal.
        /// </summary>
        /// <param name="option1">
        /// The first object to compare.
        /// </param>
        /// <param name="option2">
        /// The second object to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="option1"/> and <paramref name="option2"/> do not represent the
        /// same <see cref="System.Option{T}"/> object; otherwise, false.
        /// </returns>
        public static bool operator !=(Option<T> option1, Option<T> option2)
        {
            return !(option1 == option2);
        }

        /// <summary>
        /// Indicates whether the current <see cref="System.Option{T}"/> object is equal to another
        /// object of the <see cref="System.Option{T}"/> type.
        /// </summary>
        /// <param name="other">
        /// An object to compare with this object.
        /// </param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/>; otherwise, false.
        /// </returns>
        public bool Equals(Option<T> other)
        {
            return base.Equals(other);
        }

        private static readonly Option<T> _MZero = default(Option<T>);

        /// <summary>
        /// Gets a Monad Zero object.
        /// </summary>
        public static Option<T> MZero { get { return _MZero; } }
    }

    /// <summary>
    /// Provides a set of static methods for querying objects that <see cref="System.Option{T}"/>.
    /// </summary>
    public static class Option
    {
        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> that represents a Some value.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <param name="value">
        /// A value.
        /// </param>
        /// <returns>
        /// Some value that represents a <paramref name="value"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is null.
        /// </exception>
        public static Option<T> Some<T>(T value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return new Option<T>(value, true);
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> that represents a None value.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <returns>
        /// None value.
        /// </returns>
        public static Option<T> None<T>()
        {
            return Option<T>.MZero;
        }

        /// <summary>
        /// Applies a function to an option value.
        /// </summary>
        /// <typeparam name="TSounce">
        /// The underlying value type of the <see cref="System.Option{T}"/> of
        /// <paramref name="source"/>.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The underlying value type of the <see cref="System.Option{T}"/> returned by
        /// <paramref name="function"/>.
        /// </typeparam>
        /// <param name="source">
        /// An option value to apply a <paramref name="function"/>.
        /// </param>
        /// <param name="function">
        /// A function that takes the value from a <paramref name="source"/> and transforms it into
        /// an <see cref="System.Option{T}"/>.
        /// </param>
        /// <returns>
        /// A result of applying the <paramref name="source"/> to the <paramref name="function"/> if
        /// <paramref name="source"/> has value; otherwise, None value.
        /// </returns>
        public static Option<TResult> Bind<TSounce, TResult>(this Option<TSounce> source,
            Func<TSounce, Option<TResult>> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            if (source.HasValue)
            {
                return function(source.Value);
            }

            return None<TResult>();
        }

        /// <summary>
        /// If first <see cref="System.Option{T}"/> object has value, returns first object;
        /// otherwise, returns second <see cref="System.Option{T}"/> object.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <param name="option1">
        /// A first object.
        /// </param>
        /// <param name="option2">
        /// A second object.
        /// </param>
        /// <returns>
        /// <paramref name="option1"/> object if <paramref name="option1"/> object has value;
        /// otherwise, <paramref name="option2"/> object.
        /// </returns>
        public static Option<T> MPlus<T>(this Option<T> option1, Option<T> option2)
        {
            if (option1.HasValue) return option1;

            return option2;
        }

        /// <summary>
        /// Applies a function to an option value.
        /// </summary>
        /// <typeparam name="TSounce">
        /// The underlying value type of the <see cref="System.Option{T}"/> of
        /// <paramref name="source"/>.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The underlying value type of the <see cref="System.Option{T}"/> returned by
        /// <paramref name="function"/>.
        /// </typeparam>
        /// <param name="source">
        /// An option value to apply a <paramref name="function"/>.
        /// </param>
        /// <param name="function">
        /// A function that takes the value from a <paramref name="source"/> and transforms it into an
        /// <see cref="System.Option{T}"/>.
        /// </param>
        /// <returns>
        /// A result of applying the <paramref name="source"/> to the <paramref name="function"/> if
        /// <paramref name="source"/> has value; otherwise, None value.
        /// </returns>
        public static Option<TResult> Select<TSounce, TResult>(this Option<TSounce> source,
            Func<TSounce, Option<TResult>> function)
        {
            return Bind(source, function);
        }

        /// <summary>
        /// Applies a function to an option value, and invokes a result selector function.
        /// </summary>
        /// <typeparam name="TSource">
        /// The underlying value type of the <see cref="System.Option{T}"/> of
        /// <paramref name="source"/>.
        /// </typeparam>
        /// <typeparam name="TOther">
        /// The underlying value type of the <see cref="System.Option{T}"/> returned by
        /// <paramref name="otherSelector"/>.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The underlying value type of the <see cref="System.Option{T}"/> of result value.
        /// </typeparam>
        /// <param name="source">
        /// An option value to apply a <paramref name="otherSelector"/>.
        /// </param>
        /// <param name="otherSelector">
        /// A function that takes the value from a <paramref name="source"/> and transforms it into
        /// an <see cref="System.Option{T}"/>.
        /// </param>
        /// <param name="resultSelector">
        /// A function that takes the value from a <paramref name="source"/> and result of
        /// <paramref name="otherSelector"/>, and transforms it into an result value.
        /// </param>
        /// <returns>
        /// Some value in result of applying the <paramref name="resultSelector"/> if
        /// <paramref name="source"/> has value, result of applying the <paramref name="source"/> to
        /// the <paramref name="otherSelector"/> has value, and result of applying the
        /// <paramref name="resultSelector"/> is not null; otherwise, None value.
        /// </returns>
        public static Option<TResult> SelectMany<TSource, TOther, TResult>(this Option<TSource> source,
            Func<TSource, Option<TOther>> otherSelector,
            Func<TSource, TOther, TResult> resultSelector)
        {
            var other = source.Bind(otherSelector);

            if (source.HasValue && other.HasValue)
            {
                var result = resultSelector(source.Value, other.Value);
                if (result != null)
                {
                    return Option.Some(result);
                }
            }

            return Option.None<TResult>();
        }

        /// <summary>
        /// If first <see cref="System.Option{T}"/> object is Some value, returns first object;
        /// otherwise, returns second <see cref="System.Option{T}"/> object.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <param name="option1">
        /// A first object.
        /// </param>
        /// <param name="option2">
        /// A second object.
        /// </param>
        /// <returns>
        /// <paramref name="option1"/> object if <paramref name="option1"/> object is Some value;
        /// otherwise, <paramref name="option2"/> object.
        /// </returns>
        public static Option<T> Or<T>(this Option<T> option1, Option<T> option2)
        {
            return option1.MPlus(option2);
        }

        /// <summary>
        /// If first <see cref="System.Option{T}"/> object is Some value, returns first object
        /// value; otherwise, returns second object.
        /// </summary>
        /// <typeparam name="T">
        /// The underlying value type of the <see cref="System.Option{T}"/> generic type.
        /// </typeparam>
        /// <param name="option">
        /// A first object.
        /// </param>
        /// <param name="value">
        /// A second object.
        /// </param>
        /// <returns>
        /// <paramref name="option"/> object value if <paramref name="option"/> object is Some
        /// value; otherwise, <paramref name="value"/> object.
        /// </returns>
        public static T Or<T>(this Option<T> option, T value)
        {
            if (option.HasValue) return option.Value;

            return value;
        }
    }
}
