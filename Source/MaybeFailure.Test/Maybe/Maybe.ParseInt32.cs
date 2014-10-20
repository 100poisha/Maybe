using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseInt32Test
    {
        [Test]
        public void ParseInt32()
        {
            Maybe.ParseInt32("123").Is(Option.Some((int)123));

            Maybe.ParseInt32("foo").Is(Option.None<int>());
        }
    }
}
