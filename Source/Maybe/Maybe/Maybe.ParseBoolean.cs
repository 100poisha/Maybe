namespace System
{
    public static partial class Maybe
    {
        /// <summary>
        /// Converts the specified string representation of a logical value to its
        /// <see cref="System.Boolean"/> equivalent.
        /// </summary>
        /// <param name="value">
        /// A string containing the value to convert.
        /// </param>
        /// <returns>
        /// Some value that represents a <see cref="System.Boolean"/> type value equivalent to the
        /// boolean contained in <paramref name="value"/> if <paramref name="value"/> was converted
        /// successfully; otherwise None value.
        /// </returns>
        public static Option<Boolean> ParseBoolean(string value)
        {
            Boolean result;
            if (Boolean.TryParse(value, out result))
            {
                return Option.Some(result);
            }

            return Option.None<Boolean>();
        }
    }
}
