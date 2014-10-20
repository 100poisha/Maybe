using System.Collections.Generic;

namespace System
{
    public static partial class Maybe
    {
        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey">
        /// The type of keys in the dictionary.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The type of values in the dictionary.
        /// </typeparam>
        /// <param name="dictionary">
        /// A dictionary to return the value associated with the specified key.
        /// </param>
        /// <param name="key">
        /// A key whose value to get.
        /// </param>
        /// <returns>
        /// Some value that the represents a value associated with the specified
        /// <paramref name="key"/> from <paramref name="dictionary"/> if the <paramref name="key"/>
        /// is found in <paramref name="dictionary"/> and that value is not null; otherwise None.
        /// </returns>
        public static Option<TValue> MaybeGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            return Maybe.GetValue(dictionary, key);
        }

        /// <summary>
        /// Gets the value associated with the specified key from specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">
        /// The type of keys in the dictionary.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The type of values in the dictionary.
        /// </typeparam>
        /// <param name="dictionary">
        /// A dictionary to return the value associated with the specified key.
        /// </param>
        /// <param name="key">
        /// A key whose value to get.
        /// </param>
        /// <returns>
        /// Some value that the represents a value associated with the specified
        /// <paramref name="key"/> from <paramref name="dictionary"/> if the <paramref name="key"/>
        /// is found in <paramref name="dictionary"/> and that value is not null; otherwise None.
        /// </returns>
        public static Option<TValue> GetValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            if (dictionary == null) throw new ArgumentNullException("dictionary");

            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                if (value != null)
                {
                    return Option.Some(value);
                }
            }

            return Option.None<TValue>();
        }
    }
}
