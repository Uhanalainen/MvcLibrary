using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLibrary.Helpers
{
    public class ModelValidator
    {
        /// <summary>
        /// Validates string
        /// Returns true if valid and false if invalid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateString(string value)
        {
            if (IsStringMissing(value) || value.Length <= 2 || value.Length >= 50)
                return false;

            return true;
        }

        /// <summary>
        /// Makes sure that there actually is a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        public static bool ValidateYear(string value)
        {
            if (IsStringMissing(value) || !IsDigitsOnly(value) || value.Length < 4 || value.Length > 4)
            {
                return false;
            }
            return true;
        }

        static bool IsDigitsOnly(string value)
        {
            return value.All(c => c >= '0' && c <= '9');
        }
    }
}