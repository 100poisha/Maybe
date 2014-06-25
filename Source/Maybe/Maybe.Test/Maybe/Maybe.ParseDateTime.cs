using System;
using System.Globalization;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseDateTimeTest
    {
        [Test]
        public void ParseDateTime()
        {
            Maybe.ParseDateTime("2000/01/02 03:04:05").Is(Option.Some(new DateTime(2000, 1, 2, 3, 4, 5)));

            Maybe.ParseDateTime("foo").Is(Option.None<DateTime>());
        }

        [Test]
        public void ParseDateTimeExact()
        {
            Maybe.ParseDateTimeExact("20000102030405",
                "yyyyMMddHHmmss",
                null,
                DateTimeStyles.None)
                .Is(Option.Some(new DateTime(2000, 1, 2, 3, 4, 5)));

            Maybe.ParseDateTimeExact("foo",
                "yyyyMMddHHmmss",
                null,
                DateTimeStyles.None)
                .Is(Option.None<DateTime>());
        }
    }
}
