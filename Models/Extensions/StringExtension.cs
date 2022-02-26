using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Models.Extensions
{
    public static class StringExtension
    {
        public const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        public const string Digits = "0123456789";
        public const string FakeEmailDomain = "@ceva109367.inexistent";
        public const string Anonymized = "anonimizat";
        public static readonly char[] WordDelimiterChars = { ' ', ',', '.', ':', '-', '\t' };

        public static string RemoveNonDigitOrPlus(this string obj)
        {
            if (obj == null || obj == string.Empty)
            {
                return obj;
            }

            var str = new string((from c in obj
                                  where char.IsDigit(c) || c == '+'
                                  select c
                   ).ToArray());
            return str;
        }

        public static string NullSafeTrim(this string value)
        {
            if (value != null)
            {
                value = value.Trim();
            }

            return value;
        }

        public static string ToTrimmedLowerCase(this string value)
        {
            return (value == null) ? null : value.Trim().ToLower();
            //if (value != null)
            //{
            //    value = value.Trim();
            //    return value.ToLower();
            //}

            //return value;
        }

        public static string ToTrimmedTitleCase(this string value)
        {
            if (value != null)
            {
                value = value.Trim();
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                return ti.ToTitleCase(value.ToLower());
            }

            return value;
        }


        public static bool NotNullOrEmpty(this string value)
        {
            return value != null && value != "";
        }

        public static string ValueOrEmpty(this string value)
        {
            if (value != null)
                return value;
            return "";
        }
    }
}
