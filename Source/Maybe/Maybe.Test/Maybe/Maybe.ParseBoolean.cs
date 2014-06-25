using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeParseBooleanTest
    {
        [Test]
        public void ParseBoolean()
        {
            Maybe.ParseBoolean("true").Is(Option.Some(true));
            Maybe.ParseBoolean("FALSE").Is(Option.Some(false));

            Maybe.ParseBoolean("foo").Is(Option.None<bool>());
        }
    }
}
