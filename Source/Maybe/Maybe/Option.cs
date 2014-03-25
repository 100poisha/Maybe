namespace System
{
    public struct Option<T>
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
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

        public static bool operator ==(Option<T> lhs, Option<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Option<T> lhs, Option<T> rhs)
        {
            return !(lhs == rhs);
        }
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
            return new Option<T>(default(T), false);
        }

        public static Option<TResult> Bind<TSounce, TResult>(this Option<TSounce> self,
            Func<TSounce, Option<TResult>> func)
        {
            if (func == null) throw new ArgumentNullException("func");

            if (self.HasValue)
            {
                return func(self.Value);
            }

            return None<TResult>();
        }

        public static Option<TResult> Select<TSounce, TResult>(this Option<TSounce> self,
            Func<TSounce, Option<TResult>> func)
        {
            return Bind(self, func);
        }

        public static Option<TResult> SelectMany<TSource, TOther, TResult>(this Option<TSource> source,
            Func<TSource, Option<TOther>> otherSelector,
            Func<TSource, TOther, TResult> resultSelector)
        {
            return source.Bind(s => otherSelector(s).Bind(o => Some(resultSelector(s, o))));
        }
    }
}
