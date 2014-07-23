using System.Collections.Generic;

namespace System
{
    public static partial class Maybe
    {
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
