using System;
using NUnit.Framework;

namespace Maybe.Test
{
    using Maybe = System.Maybe;

    [TestFixture]
    class MaybeCoreTest
    {
        [Test]
        public void HasValue()
        {
            Maybe.HasValue("").HasValue.IsTrue();
            Maybe.HasValue("").Value.Is("");

            Maybe.HasValue((string)null).HasValue.IsFalse();
        }

        [Test]
        public void HasValue_Nullable()
        {
            Maybe.HasValue((int?)42).IsInstanceOf<Option<int>>();

            Maybe.HasValue((int?)42).HasValue.IsTrue();
            Maybe.HasValue((int?)42).Value.Is(42);

            Maybe.HasValue((int?)null).HasValue.IsFalse();
        }

        [Test]
        public void ToNullable()
        {
            var value = Option.Some(42).ToNullable();

            value.HasValue.IsTrue();
            value.Value.Is(42);

            value = Option.None<int>().ToNullable();

            value.HasValue.IsFalse();
        }
    }
}
