using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseByteTest
    {
        [Test]
        public void ParseByte()
        {
            Maybe.ParseByte("123").Is(Option.Some((byte)123));

            Maybe.ParseByte("foo").Is(Option.None<byte>());
        }
    }
}
