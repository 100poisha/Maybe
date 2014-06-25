using System;
using System.Globalization;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseTimeSpanTest
    {
        [Test]
        public void ParseTimeSpan()
        {
            Maybe.ParseTimeSpan("01:02:03").Is(Option.Some(new TimeSpan(1, 2, 3)));

            Maybe.ParseTimeSpan("foo").Is(Option.None<TimeSpan>());
        }

        [Test]
        public void ParseTimeSpanExact()
        {
            Maybe.ParseTimeSpanExact("010203",
                "hhmmss",
                null,
                TimeSpanStyles.None)
                .Is(Option.Some(new TimeSpan(1, 2, 3)));

            Maybe.ParseTimeSpanExact("foo",
                "hhmmss",
                null,
                TimeSpanStyles.None)
                .Is(Option.None<TimeSpan>());
        }
    }
}
