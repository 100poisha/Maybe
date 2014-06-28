using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseInt64Test
    {
        [Test]
        public void ParseInt64()
        {
            Maybe.ParseInt64("123").Is(Option.Some((long)123));

            Maybe.ParseInt64("foo").Is(Option.None<long>());
        }
    }
}
