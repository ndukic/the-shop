namespace TheShop.Domain.Common
{
    public static class FormattingExtensions
    {
        public static string TwoSpacesOrNull(this double? value)
        {
            return value.HasValue ? $"{value:0.##}" : "null";
        }

        public static string IntOrNull(this int? value)
        {
            return value.HasValue ? value.ToString() : "null";
        }
    }
}
