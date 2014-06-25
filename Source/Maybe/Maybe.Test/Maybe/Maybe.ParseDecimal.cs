using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseDecimalTest
    {
        [Test]
        public void ParseDecimal()
        {
            Maybe.ParseDecimal("123").Is(Option.Some((decimal)123));

            Maybe.ParseDecimal("foo").Is(Option.None<decimal>());
        }
    }
}
