using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseSingleTest
    {
        [Test]
        public void ParseSingle()
        {
            Maybe.ParseSingle("123").Is(Option.Some((float)123));

            Maybe.ParseSingle("foo").Is(Option.None<float>());
        }
    }
}
