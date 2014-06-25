using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseCharTest
    {
        [Test]
        public void ParseChar()
        {
            Maybe.ParseChar("a").Is(Option.Some('a'));

            Maybe.ParseChar("foo").Is(Option.None<char>());
        }
    }
}
