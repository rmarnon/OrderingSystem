using System.Text.RegularExpressions;

namespace Ordering.System.Api.Validators.Rules
{
    public static class ValidateWords
    {
        public static bool Text(string letras) => new Regex("^[A-Za-z\\s]{1,}$").IsMatch(letras);
    }
}
