using System.Globalization;

namespace System
{
    public static partial class Maybe
    {
        /// <summary>
        /// Converts the string representation of a time interval to its
        /// <see cref="System.TimeSpan"/> equivalent.
        /// </summary>
        /// <param name="s">
        /// A string that specifies the time interval to convert.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.TimeSpan"/> type value equivalent to the
        /// time interval contained in <paramref name="s"/> if <paramref name="s"/> was converted
        /// successfully; otherwise None value.
        /// </returns>
        public static Option<TimeSpan> ParseTimeSpan(string s)
        {
            TimeSpan result;
            if (TimeSpan.TryParse(s, out result))
            {
                return Option.Some(result);
            }

            return Option.None<TimeSpan>();
        }

        /// <summary>
        /// Converts the string representation of a time interval to its
        /// <see cref="System.TimeSpan"/> equivalent by using the specified culture-specific
        /// formatting information.
        /// </summary>
        /// <param name="input">
        /// A string that specifies the time interval to convert.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.TimeSpan"/> type value equivalent to the
        /// time interval contained in <paramref name="input"/> if <paramref name="input"/> was
        /// converted successfully; otherwise None value.
        /// </returns>
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

        /// <summary>
        /// Converts the string representation of a time interval to its
        /// <see cref="System.TimeSpan"/> equivalent by using the specified format and
        /// culture-specific format information.
        /// </summary>
        /// <param name="input">
        /// A string that specifies the time interval to convert.
        /// </param>
        /// <param name="format">
        /// A standard or custom format string that defines the required format of
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.TimeSpan"/> type value equivalent to the
        /// time interval contained in <paramref name="input"/> if <paramref name="input"/> was
        /// converted successfully; otherwise None value.
        /// </returns>
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

        /// <summary>
        /// Converts the string representation of a time interval to its 
        /// <see cref="System.TimeSpan"/> equivalent by using the specified formats and
        /// culture-specific format information.
        /// </summary>
        /// <param name="input">
        /// A string that specifies the time interval to convert.
        /// </param>
        /// <param name="formats">
        /// A array of standard or custom format strings that define the acceptable formats of
        /// input.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.TimeSpan"/> type value equivalent to the
        /// time interval contained in <paramref name="input"/> if <paramref name="input"/> was
        /// converted successfully; otherwise None value.
        /// </returns>
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

        /// <summary>
        /// Converts the string representation of a time interval to its
        /// <see cref="System.TimeSpan"/> equivalent by using the specified format, culture-specific
        /// format information, and styles.
        /// </summary>
        /// <param name="input">
        /// A string that specifies the time interval to convert.
        /// </param>
        /// <param name="format">
        /// A standard or custom format string that defines the required format of
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="styles">
        /// One or more enumeration values that indicate the style of <paramref name="input"/>.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.TimeSpan"/> type value equivalent to the
        /// time interval contained in <paramref name="input"/> if <paramref name="input"/> was
        /// converted successfully; otherwise None value.
        /// </returns>
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

        /// <summary>
        /// Converts the string representation of a time interval to its
        /// <see cref="System.TimeSpan"/> equivalent by using the specified formats,
        /// culture-specific format information, and styles.
        /// </summary>
        /// <param name="input">
        /// A string that specifies the time interval to convert.
        /// </param>
        /// <param name="formats">
        /// A array of standard or custom format strings that define the acceptable formats of
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="styles">
        /// One or more enumeration values that indicate the style of <paramref name="input"/>.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.TimeSpan"/> type value equivalent to the
        /// time interval contained in <paramref name="input"/> if <paramref name="input"/> was
        /// converted successfully; otherwise None value.
        /// </returns>
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
