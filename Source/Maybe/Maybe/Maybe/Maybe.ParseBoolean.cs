namespace System
{
    public static partial class Maybe
    {
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
