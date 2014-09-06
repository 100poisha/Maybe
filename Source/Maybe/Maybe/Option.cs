namespace System
{
    public struct Option<T> : IEquatable<Option<T>>
    {
        internal Option(T value, bool hasValue)
        {
            _Value = value;
            _HasValue = hasValue;
        }

        private readonly T _Value;

        public T Value
        {
            get
            {
                if (!HasValue) throw new InvalidOperationException("Option object must have a value.");

                return _Value;
            }
        }

        private readonly bool _HasValue;

        public bool HasValue
        {
            get { return _HasValue; }
        }

        public override string ToString()
        {
            if (HasValue) return string.Format("Some({0})", Value);
            else return "None";
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

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

        public static bool operator ==(Option<T> option1, Option<T> option2)
        {
            return option1.Equals(option2);
        }

        public static bool operator !=(Option<T> option1, Option<T> option2)
        {
            return !(option1 == option2);
        }

        public bool Equals(Option<T> other)
        {
            return base.Equals(other);
        }

        private static readonly Option<T> _MZero = default(Option<T>);

        public static Option<T> MZero { get { return _MZero; } }
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return new Option<T>(value, true);
        }

        public static Option<T> None<T>()
        {
            return Option<T>.MZero;
        }

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

        public static Option<T> MPlus<T>(this Option<T> option1, Option<T> option2)
        {
            if (option1.HasValue) return option1;

            return option2;
        }

        public static Option<TResult> Select<TSounce, TResult>(this Option<TSounce> source,
            Func<TSounce, Option<TResult>> function)
        {
            return Bind(source, function);
        }

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

        public static Option<T> Or<T>(this Option<T> option1, Option<T> option2)
        {
            return option1.MPlus(option2);
        }

        public static T Or<T>(this Option<T> option, T value)
        {
            if (option.HasValue) return option.Value;

            return value;
        }
    }
}
