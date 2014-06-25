using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseInt16Test
    {
        [Test]
        public void ParseInt16()
        {
            Maybe.ParseInt16("123").Is(Option.Some((short)123));

            Maybe.ParseInt16("foo").Is(Option.None<short>());
        }
    }
}
