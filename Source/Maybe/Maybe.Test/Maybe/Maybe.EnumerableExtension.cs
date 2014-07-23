using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;
    using System.Linq;

    [TestFixture]
    class MaybeEnumerableExtensionTest
    {
        [Test]
        public void ElementAtOrNone()
        {
            var array = new[] { 1, 2, 3 };

            array.ElementAtOrNone(0).Is(Option.Some(1));
            array.ElementAtOrNone(1).Is(Option.Some(2));
            array.ElementAtOrNone(2).Is(Option.Some(3));

            array.ElementAtOrNone(-1).Is(Option.None<int>());
            array.ElementAtOrNone(3).Is(Option.None<int>());

            var list = new List<int>() { 1, 2, 3 };

            list.ElementAtOrNone(0).Is(Option.Some(1));
            list.ElementAtOrNone(1).Is(Option.Some(2));
            list.ElementAtOrNone(2).Is(Option.Some(3));

            list.ElementAtOrNone(-1).Is(Option.None<int>());
            list.ElementAtOrNone(3).Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 3);

            enumerable.ElementAtOrNone(0).Is(Option.Some(1));
            enumerable.ElementAtOrNone(1).Is(Option.Some(2));
            enumerable.ElementAtOrNone(2).Is(Option.Some(3));

            enumerable.ElementAtOrNone(-1).Is(Option.None<int>());
            enumerable.ElementAtOrNone(3).Is(Option.None<int>());
        }

        [Test]
        public void ElementAtOrNone_NullValue()
        {
            var array = new[] { "foo", "bar", null };

            array.ElementAtOrNone(0).Is(Option.Some("foo"));
            array.ElementAtOrNone(1).Is(Option.Some("bar"));
            array.ElementAtOrNone(2).Is(Option.None<string>());

            var list = new List<string>() { "foo", "bar", null };

            list.ElementAtOrNone(0).Is(Option.Some("foo"));
            list.ElementAtOrNone(1).Is(Option.Some("bar"));
            list.ElementAtOrNone(2).Is(Option.None<string>());

            var enumerable = Enumerable.Repeat("foo", 1)
                .Concat(Enumerable.Repeat("bar", 1))
                .Concat(Enumerable.Repeat((string)null, 1));

            enumerable.ElementAtOrNone(0).Is(Option.Some("foo"));
            enumerable.ElementAtOrNone(1).Is(Option.Some("bar"));
            enumerable.ElementAtOrNone(2).Is(Option.None<string>());
        }

        [Test]
        public void FirstOrNone()
        {
            var array = new[] { 1, 2, 3 };

            array.FirstOrNone().Is(Option.Some(1));

            var list = new List<int>() { 1, 2, 3 };

            list.FirstOrNone().Is(Option.Some(1));

            var enumerable = Enumerable.Range(1, 3);

            enumerable.FirstOrNone().Is(Option.Some(1));
        }

        [Test]
        public void FirstOrNone_Empty()
        {
            var array = new int[] { };

            array.FirstOrNone().Is(Option.None<int>());

            var list = new List<int>();

            list.FirstOrNone().Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 0);

            enumerable.FirstOrNone().Is(Option.None<int>());
        }

        [Test]
        public void FirstOrNone_NullValue()
        {
            var array = new string[] { null, "foo", "bar" };

            array.FirstOrNone().Is(Option.None<string>());

            var list = new List<string>() { null, "foo", "bar" };

            list.FirstOrNone().Is(Option.None<string>());

            var enumerable = Enumerable.Repeat((string)null, 1)
                .Concat(Enumerable.Repeat("foo", 1))
                .Concat(Enumerable.Repeat("bar", 1));

            enumerable.FirstOrNone().Is(Option.None<string>());
        }

        [Test]
        public void FirstOrNone_Predicate()
        {
            var array = new[] { 1, 2, 3, 4 };

            array.FirstOrNone(i => i % 2 == 0).Is(Option.Some(2));
            array.FirstOrNone(i => i % 5 == 0).Is(Option.None<int>());

            var list = new List<int>() { 1, 2, 3, 4 };

            list.FirstOrNone(i => i % 2 == 0).Is(Option.Some(2));
            list.FirstOrNone(i => i % 5 == 0).Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 4);

            enumerable.FirstOrNone(i => i % 2 == 0).Is(Option.Some(2));
            enumerable.FirstOrNone(i => i % 5 == 0).Is(Option.None<int>());
        }

        [Test]
        public void FirstOrNone_Predicate_Empty()
        {
            var array = new int[] { };

            array.FirstOrNone(i => i % 2 == 0).Is(Option.None<int>());

            var list = new List<int>();

            list.FirstOrNone(i => i % 2 == 0).Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 0);

            enumerable.FirstOrNone(i => i % 2 == 0).Is(Option.None<int>());
        }

        [Test]
        public void FirstOrNone_Predicate_NullValue()
        {
            var array = new string[] { null };

            array.FirstOrNone(s => s == null).Is(Option.None<string>());

            var list = new List<string>() { null };

            list.FirstOrNone(s => s == null).Is(Option.None<string>());

            var enumerable = Enumerable.Repeat((string)null, 1);

            enumerable.FirstOrNone(s => s == null).Is(Option.None<string>());
        }

        [Test]
        public void LastOrNone()
        {
            var array = new[] { 1, 2, 3 };

            array.LastOrNone().Is(Option.Some(3));

            var list = new List<int>() { 1, 2, 3 };

            list.LastOrNone().Is(Option.Some(3));

            var enumerable = Enumerable.Range(1, 3);

            enumerable.LastOrNone().Is(Option.Some(3));
        }

        [Test]
        public void LastOrNone_Empty()
        {
            var array = new int[] { };

            array.LastOrNone().Is(Option.None<int>());

            var list = new List<int>();

            list.LastOrNone().Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 0);

            enumerable.LastOrNone().Is(Option.None<int>());
        }

        [Test]
        public void LastOrNone_NullValue()
        {
            var array = new string[] { "foo", "bar", null };

            array.LastOrNone().Is(Option.None<string>());

            var list = new List<string>() { "foo", "bar", null };

            list.LastOrNone().Is(Option.None<string>());

            var enumerable = Enumerable.Repeat("foo", 1)
                .Concat(Enumerable.Repeat("bar", 1))
                .Concat(Enumerable.Repeat((string)null, 1));

            enumerable.LastOrNone().Is(Option.None<string>());
        }

        [Test]
        public void LastOrNone_Predicate()
        {
            var array = new[] { 1, 2, 3, 4 };

            array.LastOrNone(i => i % 2 != 0).Is(Option.Some(3));
            array.LastOrNone(i => i % 5 == 0).Is(Option.None<int>());

            var list = new List<int>() { 1, 2, 3, 4 };

            list.LastOrNone(i => i % 2 != 0).Is(Option.Some(3));
            list.LastOrNone(i => i % 5 == 0).Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 4);

            enumerable.LastOrNone(i => i % 2 != 0).Is(Option.Some(3));
            enumerable.LastOrNone(i => i % 5 == 0).Is(Option.None<int>());
        }

        [Test]
        public void LastOrNone_Predicate_Empty()
        {
            var array = new int[] { };

            array.LastOrNone(i => i % 2 != 0).Is(Option.None<int>());

            var list = new List<int>();

            list.LastOrNone(i => i % 2 != 0).Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 0);

            enumerable.LastOrNone(i => i % 2 != 0).Is(Option.None<int>());
        }

        [Test]
        public void LastOrNone_Predicate_NullValue()
        {
            var array = new string[] { "foo", "bar", null };

            array.LastOrNone(s => s == null).Is(Option.None<string>());

            var list = new List<string>() { "foo", "bar", null };

            list.LastOrNone(s => s == null).Is(Option.None<string>());

            var enumerable = Enumerable.Repeat("foo", 1)
                .Concat(Enumerable.Repeat("bar", 1))
                .Concat(Enumerable.Repeat((string)null, 1));

            enumerable.LastOrNone(s => s == null).Is(Option.None<string>());
        }

        [Test]
        public void SingleOrNone()
        {
            var array = new[] { 1 };

            array.SingleOrNone().Is(Option.Some(1));

            var list = new List<int>() { 1 };

            list.SingleOrNone().Is(Option.Some(1));

            var enumerable = Enumerable.Range(1, 1);

            enumerable.SingleOrNone().Is(Option.Some(1));
        }

        [Test]
        public void SingleOrNone_Empty()
        {
            var array = new int[] { };

            array.SingleOrNone().Is(Option.None<int>());

            var list = new List<int>();

            list.SingleOrNone().Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 0);

            enumerable.SingleOrNone().Is(Option.None<int>());
        }

        [Test]
        public void SingleOrNone_NullValue()
        {
            var array = new string[] { null };

            array.SingleOrNone().Is(Option.None<string>());

            var list = new List<string>() { null };

            list.SingleOrNone().Is(Option.None<string>());

            var enumerable = Enumerable.Repeat((string)null, 1);

            enumerable.SingleOrNone().Is(Option.None<string>());
        }

        [Test]
        public void SingleOrNone_MoreThanOneElement_Error()
        {
            var array = new[] { 1, 2 };

            Assert.Catch <InvalidOperationException>(() =>
                {
                    array.SingleOrNone();
                });

            var list = new List<int>() { 1, 2 };

            Assert.Catch<InvalidOperationException>(() =>
            {
                list.SingleOrNone();
            }); ;

            var enumerable = Enumerable.Range(1, 2);

            Assert.Catch<InvalidOperationException>(() =>
            {
                enumerable.SingleOrNone();
            });
        }

        [Test]
        public void SingleOrNone_Predicate()
        {
            var array = new[] { 1, 2, 3 };

            array.SingleOrNone(i => i % 2 == 0).Is(Option.Some(2));

            var list = new List<int>() { 1, 2, 3 };

            list.SingleOrNone(i => i % 2 == 0).Is(Option.Some(2));

            var enumerable = Enumerable.Range(1, 3);

            enumerable.SingleOrNone(i => i % 2 == 0).Is(Option.Some(2));
        }

        [Test]
        public void SingleOrNone_Predicate_Empty()
        {
            var array = new int[] { 1, 2, 3 };

            array.SingleOrNone(i => i % 5 == 0).Is(Option.None<int>());

            var list = new List<int>() { 1, 2, 3 };

            list.SingleOrNone(i => i % 5 == 0).Is(Option.None<int>());

            var enumerable = Enumerable.Range(1, 0);

            enumerable.SingleOrNone(i => i % 5 == 0).Is(Option.None<int>());
        }

        [Test]
        public void SingleOrNone_Predicate_NullValue()
        {
            var array = new string[] { "foo", "bar", null };

            array.SingleOrNone(s => s == null).Is(Option.None<string>());

            var list = new List<string>() { "foo", "bar", null };

            list.SingleOrNone(s => s == null).Is(Option.None<string>());

            var enumerable = Enumerable.Repeat("foo", 1)
                .Concat(Enumerable.Repeat("bar", 1))
                .Concat(Enumerable.Repeat((string)null, 1)); ;

            enumerable.SingleOrNone(s => s == null).Is(Option.None<string>());
        }

        [Test]
        public void SingleOrNone_Predicate_MoreThanOneElement_Error()
        {
            var array = new[] { 1, 2, 3, 4 };

            Assert.Catch<InvalidOperationException>(() =>
            {
                array.SingleOrNone(i => i % 2 == 0);
            });

            var list = new List<int>() { 1, 2, 3, 4 };

            Assert.Catch<InvalidOperationException>(() =>
            {
                list.SingleOrNone(i => i % 2 == 0);
            }); ;

            var enumerable = Enumerable.Range(1, 4);

            Assert.Catch<InvalidOperationException>(() =>
            {
                enumerable.SingleOrNone(i => i % 2 == 0);
            });
        }
    }
}
