using System.Collections.Generic;

namespace System
{
    public static partial class Maybe
    {
        public static Option<TValue> MaybeGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            return Maybe.GetValue(dictionary, key);
        }

        public static Option<TValue> GetValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            if (dictionary == null) throw new ArgumentNullException("dictionary");

            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return Option.Some(value);
            }

            return Option.None<TValue>();
        }
    }
}
