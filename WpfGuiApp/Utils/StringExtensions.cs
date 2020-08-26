namespace WpfGuiApp.Utils
{
    public static class StringExtensions
    {
        public static string TrimEnd(this string source, string value)
        {
            return source.Remove(source.LastIndexOf(value));
        }
    }
}