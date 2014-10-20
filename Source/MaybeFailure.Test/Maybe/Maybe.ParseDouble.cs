using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseDoubleTest
    {
        [Test]
        public void ParseDouble()
        {
            Maybe.ParseDouble("123").Is(Option.Some((double)123));

            Maybe.ParseDouble("foo").Is(Option.None<double>());
        }
    }
}
