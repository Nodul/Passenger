using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Helpers
{
    public static class Validation
    {
        public static string ValidateString(string str, bool ToLowerInvariant = true)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("String cannot be null or whitespace!");
            }
            str = str.Trim();
            if (ToLowerInvariant) str = str.ToLowerInvariant();
            return str;

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

        /// <summary>
        /// TODO. Will simply run ValidateString for now
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string ValidateAddress(string address)
        {
          
            if (address == null) throw new ArgumentException("Address cannot be null");
            // temporary
            return ValidateString(address,false);
        }

        public static bool ValidateLatitude(double latitude)
        {
            if(latitude < 0)
            {
                throw new ArgumentException("Lattitude cannot be less than 0");
            }
            if(latitude > 90)
            {
                throw new ArgumentException("Lattitude cannot be more than 90");
            }
            return true;
        }

        public static bool ValidateLongitude(double longitude)
        {
            if (longitude < 0)
            {
                throw new ArgumentException("Longitude cannot be less than 0");
            }
            if(longitude > 180)
            {
                throw new ArgumentException("Longitude cannot be more than 180");
            }
            return true;
        }
    }
}
