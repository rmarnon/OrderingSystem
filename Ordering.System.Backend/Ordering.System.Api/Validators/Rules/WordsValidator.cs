using System.Text.RegularExpressions;

namespace Ordering.System.Api.Validators.Rules
{
    public static class WordsValidator
    {
        public static bool IsValidText(string letras) => new Regex("^[A-Za-z-0-9\\s]{1,}$").IsMatch(letras);
    }
}
