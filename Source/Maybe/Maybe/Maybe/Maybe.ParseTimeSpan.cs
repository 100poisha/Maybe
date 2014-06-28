using System.Globalization;

namespace System
{
    public static partial class Maybe
    {
        public static Option<TimeSpan> ParseTimeSpan(string s)
        {
            TimeSpan result;
            if (TimeSpan.TryParse(s, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }

        public static Option<TimeSpan> ParseTimeSpan(string input,
            IFormatProvider formatProvider)
        {
            TimeSpan result;
            if (TimeSpan.TryParse(input, formatProvider, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }

        public static Option<TimeSpan> ParseTimeSpanExact(string input,
            string format,
            IFormatProvider formatProvider)
        {
            TimeSpan result;
            if (TimeSpan.TryParseExact(input, format, formatProvider, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }

        public static Option<TimeSpan> ParseTimeSpanExact(string input,
            string[] formats,
            IFormatProvider formatProvider)
        {
            TimeSpan result;
            if (TimeSpan.TryParseExact(input, formats, formatProvider, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }

        public static Option<TimeSpan> ParseTimeSpanExact(string input,
            string format,
            IFormatProvider formatProvider,
            TimeSpanStyles styles)
        {
            TimeSpan result;
            if (TimeSpan.TryParseExact(input, format, formatProvider, styles, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }

        public static Option<TimeSpan> ParseTimeSpanExact(string input,
            string[] formats,
            IFormatProvider formatProvider,
            TimeSpanStyles styles)
        {
            TimeSpan result;
            if (TimeSpan.TryParseExact(input, formats, formatProvider, styles, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }
    }
}
