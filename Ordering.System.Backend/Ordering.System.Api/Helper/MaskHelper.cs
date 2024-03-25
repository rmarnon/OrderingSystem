using System.Text.RegularExpressions;

namespace Ordering.System.Api.Helper
{
    public static class MaskHelper
    {
        public static string FormatCNPJ(string cnpj)
        {
            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
