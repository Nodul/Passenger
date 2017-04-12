using System;
using System.Text.RegularExpressions;

namespace Passenger.Common
{
    public static class StringValidation
    {
        public static string ValidateString(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("String cannot be null or whitespace!");
            }
            return str.Trim().ToLowerInvariant();

        }

        public static string ValidateEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace!");
            }
            var temp = email.Trim().ToLowerInvariant();

            bool isEmail = Regex.IsMatch(
                temp,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);

            if (isEmail) return temp;
            else throw new ArgumentException("Invalid email address");

        }
    }
}
