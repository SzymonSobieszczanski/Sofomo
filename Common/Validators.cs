using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sofomo
{
    public static class Validators
    {
        public static bool  IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }

        public static bool IsIp(string url)
        {
            var parts = url.Split('.');
            return  parts.Length == 4
                           && !parts.Any(
                               x =>
                               {
                                   int y;
                                   return Int32.TryParse(x, out y) && y > 255 || y < 1;
                               });
        }
    }
}
