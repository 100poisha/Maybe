using System.Globalization;

namespace System
{
    public static partial class Maybe
    {
        /// <summary>
        /// Converts the string representation of a date and time to its
        /// <see cref="System.DateTime"/> equivalent.
        /// </summary>
        /// <param name="s">
        /// A string containing a date and time to convert.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.DateTime"/> type value equivalent to the
        /// date and time contained in <paramref name="s"/> if <paramref name="s"/> was converted
        /// successfully; otherwise None value.
        /// </returns>
        public static Option<DateTime> ParseDateTime(string s)
        {
            DateTime result;
            if (DateTime.TryParse(s, out result))
            {
                return Option.Some(result);
            }

            return Option.None<DateTime>();
        }

        /// <summary>
        /// Converts the string representation of a date and time to its
        /// <see cref="System.DateTime"/> equivalent using the specified culture-specific format
        /// information and formatting style.
        /// </summary>
        /// <param name="s">
        /// A string containing a date and time to convert.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="s"/>.
        /// </param>
        /// <param name="styles">
        /// A bitwise combination of enumeration values that defines how to interpret the parsed
        /// date in relation to the current time zone or the current date.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.DateTime"/> type value equivalent to the
        /// date and time contained in <paramref name="s"/> if <paramref name="s"/> was converted
        /// successfully; otherwise None value.
        /// </returns>
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

        /// <summary>
        /// Converts the string representation of a date and time to its
        /// <see cref="System.DateTime"/> equivalent using the specified format, culture-specific
        /// format information, and style.
        /// </summary>
        /// <param name="s">
        /// A string containing a date and time to convert.
        /// </param>
        /// <param name="format">
        /// The required format of <paramref name="s"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="s"/>.
        /// </param>
        /// <param name="styles">
        /// A bitwise combination of enumeration values that defines how to interpret the parsed
        /// date in relation to the current time zone or the current date.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.DateTime"/> type value equivalent to the
        /// date and time contained in <paramref name="s"/> if <paramref name="s"/> was converted
        /// successfully; otherwise None value.
        /// </returns>
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

        /// <summary>
        /// Converts the specified string representation of a date and time to its
        /// <see cref="System.DateTime"/> equivalent using the specified array of formats,
        /// culture-specific format information, and style.
        /// </summary>
        /// <param name="s">
        /// A string containing a date and time to convert.
        /// </param>
        /// <param name="formats">
        /// An array of allowable formats of <paramref name="s"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about
        /// <paramref name="s"/>.
        /// </param>
        /// <param name="styles">
        /// A bitwise combination of enumeration values that defines how to interpret the parsed
        /// date in relation to the current time zone or the current date.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.DateTime"/> type value equivalent to the
        /// date and time contained in <paramref name="s"/> if <paramref name="s"/> was converted
        /// successfully; otherwise None value.
        /// </returns>
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
