namespace System
{
    public static partial class Maybe
    {
        /// <summary>
        /// Converts the string to its equivalent Unicode character.
        /// </summary>
        /// <param name="s">
        /// A string that contains a single character.
        /// </param>
        /// <returns>
        /// Returns an <see cref="System.Option{T}"/> that represents a Some value that represents a
        /// <see cref="System.Char"/> type value equivalent to the sole character contained in
        /// <paramref name="s"/> if <paramref name="s"/> was converted successfully; otherwise None.
        /// </returns>
        public static Option<Char> ParseChar(string s)
        {
            Char result;
            if (Char.TryParse(s, out result))
            {
                return Option.Some(result);
            }

            return Option.None<Char>();
        }
    }
}