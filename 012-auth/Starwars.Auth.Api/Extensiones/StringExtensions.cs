namespace Starwars.Auth.Api.Extensiones
{
    public static class StringExtensions
    {
        public static bool NotEmpty(this string? value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
