using System.Collections.Generic;

namespace System
{
    public static partial class Maybe
    {
        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the element at a specified index in a sequence, or a None value if the index
        /// is out of range.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// The <see cref="System.Collections.Generic.IEnumerable{T}"/> to return an element from.
        /// </param>
        /// <param name="index">
        /// The zero-based index of the element to retrieve.
        /// </param>
        /// <returns>
        /// Some value that represents the element at a <paramref name="index"/> in a
        /// <paramref name="source"/> if a <paramref name="index"/> is inside the bounds of the
        /// <paramref name="source"/> sequence and element at a <paramref name="index"/> in a
        /// <paramref name="source"/> sequence is not null; otherwise None value.
        /// </returns>
        public static Option<TSource> ElementAtOrNone<TSource>(this IEnumerable<TSource> source,
            int index)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (index < 0) return Option.None<TSource>();

            var list = source as IList<TSource>;
            if (list != null)
            {
                if (index < list.Count)
                {
                    var value = list[index];
                    return value != null
                        ? Option.Some(value)
                        : Option.None<TSource>();
                }

                return Option.None<TSource>();
            }

            foreach (var element in source)
            {
                if (index == 0)
                {
                    return element != null
                        ? Option.Some(element)
                        : Option.None<TSource>();
                }
                index--;
            }

            return Option.None<TSource>();
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the first element of a sequence, or a None value if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// The <see cref="System.Collections.Generic.IEnumerable{T}"/> to return the first element
        /// of.
        /// </param>
        /// <returns>
        /// Some value that represents the first element of a <paramref name="source"/> if
        /// <paramref name="source"/> is not empty and first element of a <paramref name="source"/>
        /// is not null; otherwise None value.
        /// </returns>
        public static Option<TSource> FirstOrNone<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var list = source as IList<TSource>;
            if (list != null)
            {
                if (0 < list.Count)
                {
                    var value = list[0];
                    return value != null
                        ? Option.Some(value)
                        : Option.None<TSource>();
                }

                return Option.None<TSource>();
            }

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var value = enumerator.Current;
                    return value != null
                        ? Option.Some(value)
                        : Option.None<TSource>();
                }
            }

            return Option.None<TSource>();
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the first element of the sequence that satisfies a specified condition, or a
        /// None value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// An <see cref="System.Collections.Generic.IEnumerable{T}"/> to return an element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// Some value that represents the first element of a <paramref name="source"/> that passes
        /// the test specified by <paramref name="predicate"/> if <paramref name="source"/> is not
        /// empty, one or more element of a <paramref name="source"/> passes the test specified by
        /// <paramref name="predicate"/>, and first element of a <paramref name="source"/> that
        /// passes the test specified by <paramref name="predicate"/> is not null; otherwise None
        /// value.
        /// </returns>
        public static Option<TSource> FirstOrNone<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element != null
                        ? Option.Some(element)
                        : Option.None<TSource>();
                }
            }

            return Option.None<TSource>();
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the last element of a sequence, or a None value if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// The <see cref="System.Collections.Generic.IEnumerable{T}"/> to return the last element
        /// of.
        /// </param>
        /// <returns>
        /// Some value that represents the last element of a <paramref name="source"/> if
        /// <paramref name="source"/> is not empty and last element of a <paramref name="source"/>
        /// is not null; otherwise None value.
        /// </returns>
        public static Option<TSource> LastOrNone<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var list = source as IList<TSource>;
            if (list != null)
            {
                if (0 < list.Count)
                {
                    var value = list[list.Count - 1];
                    return value != null
                        ? Option.Some(value)
                        : Option.None<TSource>();
                }

                return Option.None<TSource>();
            }

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    TSource result;
                    do
                    {
                        result = enumerator.Current;
                    }
                    while (enumerator.MoveNext());

                    return result != null
                        ? Option.Some(result)
                        : Option.None<TSource>();
                }
            }

            return Option.None<TSource>();
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the last element of the sequence that satisfies a specified condition, or a
        /// None value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// An <see cref="System.Collections.Generic.IEnumerable{T}"/> to return an element from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// Some value that represents the last element of a <paramref name="source"/> that passes
        /// the test specified by <paramref name="predicate"/> if <paramref name="source"/> is not
        /// empty, one or more element of a <paramref name="source"/> passes the test specified by
        /// <paramref name="predicate"/>, and last element of a <paramref name="source"/> that
        /// passes the test specified by <paramref name="predicate"/> is not null; otherwise None
        /// value.
        /// </returns>
        public static Option<TSource> LastOrNone<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            bool some = false;
            TSource result = default(TSource);
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    some = true;
                    result = element;
                }
            }

            if (some)
            {
                return result != null
                    ? Option.Some(result)
                    : Option.None<TSource>();
            }

            return Option.None<TSource>();
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the only element of a sequence, or a None value if the sequence is empty.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// The <see cref="System.Collections.Generic.IEnumerable{T}"/> to return the signle element
        /// of.
        /// </param>
        /// <returns>
        /// Some value that represents the single element of a <paramref name="source"/> if
        /// <paramref name="source"/> is not empty and single element of a <paramref name="source"/>
        /// is not null; otherwise None value.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// The input sequence contains more than one element.
        /// </exception>
        public static Option<TSource> SingleOrNone<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var list = source as IList<TSource>;
            if (list != null)
            {
                if (list.Count == 0)
                {
                    return Option.None<TSource>();
                }
                else if (list.Count == 1)
                {
                    return list[0] != null
                        ? Option.Some(list[0])
                        : Option.None<TSource>();
                }
                else
                {
                    throw new InvalidOperationException("The input sequence contains more than one element.");
                }
            }
            else
            {
                using (var enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return Option.None<TSource>();
                    }

                    var result = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return result != null
                            ? Option.Some(result)
                            : Option.None<TSource>();
                    }
                    else
                    {
                        throw new InvalidOperationException("The input sequence contains more than one element.");
                    }
                }
            }
        }

        /// <summary>
        /// Returns an <see cref="System.Option{T}"/> object that represents a Some value that
        /// represents the only element of the sequence that satisfies a specified condition, or a
        /// None value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        /// An <see cref="System.Collections.Generic.IEnumerable{T}"/> to return a single element
        /// from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// Some value that represents the single element of a <paramref name="source"/> that passes
        /// the test specified by <paramref name="predicate"/> if <paramref name="source"/> is not
        /// empty, single element of a <paramref name="source"/> passes the test specified by
        /// <paramref name="predicate"/>, and single element of a <paramref name="source"/> that
        /// passes the test specified by <paramref name="predicate"/> is not null; otherwise None
        /// value.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// More than one element satisfies the condition in predicate.
        /// </exception>
        public static Option<TSource> SingleOrNone<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            bool found = false;
            TSource result = default(TSource);
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    if (found)
                    {
                        throw new InvalidOperationException("More than one element satisfies the condition in predicate.");
                    }
                    found = true;

                    result = element;
                }
            }

            if (found)
            {
                return result != null
                    ? Option.Some(result)
                    : Option.None<TSource>();
            }

            return Option.None<TSource>();
        }
    }
}
