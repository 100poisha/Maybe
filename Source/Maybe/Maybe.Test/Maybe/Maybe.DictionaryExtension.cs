using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeDictionaryExtensionTest
    {
        [Test]
        public void MaybeGetValue()
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "foo", "hoge" },
                { "bar", "fuga" },
                { "baz", "piyo" },
                { "qux", "nyoro" },
            };

            dictionary.MaybeGetValue("foo").Is(Option.Some("hoge"));
            dictionary.MaybeGetValue("bar").Is(Option.Some("fuga"));
            dictionary.MaybeGetValue("baz").Is(Option.Some("piyo"));
            dictionary.MaybeGetValue("qux").Is(Option.Some("nyoro"));

            dictionary.MaybeGetValue("foobar").Is(Option.None<string>());
        }

        [Test]
        public void MaybeGetValue_NullValue()
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "foo", null },
            };

            dictionary.MaybeGetValue("foo").Is(Option.None<string>());
        }

        [Test]
        public void GetValue()
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "foo", "hoge" },
                { "bar", "fuga" },
                { "baz", "piyo" },
                { "qux", "nyoro" },
            };

            Maybe.GetValue(dictionary, "foo").Is(Option.Some("hoge"));
            Maybe.GetValue(dictionary, "bar").Is(Option.Some("fuga"));
            Maybe.GetValue(dictionary, "baz").Is(Option.Some("piyo"));
            Maybe.GetValue(dictionary, "qux").Is(Option.Some("nyoro"));

            Maybe.GetValue(dictionary, "foobar").Is(Option.None<string>());
        }


        [Test]
        public void GetValue_NullValue()
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "foo", null },
            };

            Maybe.GetValue(dictionary, "foo").Is(Option.None<string>());
        }
    }
}
