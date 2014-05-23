using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class Maybe
    {
        public static Option<T> HasValue<T>(T value)
            where T: class
        {
            if (value == null) return Option.None<T>();

            return Option.Some(value);
        }
    }
}
