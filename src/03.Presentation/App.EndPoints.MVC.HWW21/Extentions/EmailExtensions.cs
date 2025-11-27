using System.Text.RegularExpressions;

namespace App.EndPoints.MVC.HWW21.Extentions
{
    public static class EmailExtensions
    {
        private static readonly Regex EmailRegex = new Regex(
         @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
         RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }
    }
}