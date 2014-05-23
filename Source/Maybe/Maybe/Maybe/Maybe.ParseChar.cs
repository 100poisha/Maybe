namespace System
{
    public static partial class Maybe
    {
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