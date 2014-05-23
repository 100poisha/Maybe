using System.Globalization;

namespace System
{
    public static partial class Maybe
    {
        public static Option<DateTime> ParseDateTime(string s)
        {
            DateTime result;
            if (DateTime.TryParse(s, out result))
            {
                return Option.Some(result);
            }

            return Option.None<DateTime>();
        }

        public static Option<DateTime> ParseDateTime(string s,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            DateTime result;
            if (DateTime.TryParse(s, provider, styles, out result))
            {
                return Option.Some(result);
            }

            return Option.None<DateTime>();
        }

        public static Option<DateTime> ParseDateTimeExact(string s,
            string format,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            DateTime result;
            if (DateTime.TryParseExact(s, format, provider, styles, out result))
            {
                return Option.Some(result);
            }

            return Option.None<DateTime>();
        }

        public static Option<DateTime> ParseDateTimeExact(string s,
            string[] formats,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            DateTime result;
            if (DateTime.TryParseExact(s, formats, provider, styles, out result))
            {
                return Option.Some(result);
            }

            return Option.None<DateTime>();
        }
    }
}
