using System.Text.RegularExpressions;

namespace Ordering.System.Api.Validators.Rules
{
    public static class CnpjValidator
    {
        public static bool IsValidCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            cnpj = Regex.Replace(cnpj, "[^0-9]", string.Empty);

            if (cnpj.Length != 14)
                return false;

            int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int digit1 = ExtractDigit(cnpj, multiplier1);
            int digit2 = ExtractDigit(cnpj, multiplier2);

            return digit1 == int.Parse(cnpj[12].ToString())
                && digit2 == int.Parse(cnpj[13].ToString());
        }

        private static int ExtractDigit(string cnpj, int[] multiplier)
        {
            int sum = 0;
            for (int i = 0; i < multiplier.Length; i++)
            {
                sum += int.Parse(cnpj[i].ToString()) * multiplier[i];
            }

            int digit = sum % 11;
            return digit < 2 ? 0 : 11 - digit;
        }
    }
}
