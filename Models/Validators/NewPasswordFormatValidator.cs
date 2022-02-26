using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Models.Validators
{
    public class NewPasswordFormatValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = Convert.ToString(value);

            var input = password;
            var t = password.Trim();
            if (!t.Length.Equals(input.Length))
            {
                ErrorMessage = "Parola nu paote sa inceapa sau sa se termine cu spatiu liber.";
                return false;
            }
            var MIN_LEN = 6;

            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Parola nu paote contine doar spatii libere.";
                return false;
            }

            if (input.Length < MIN_LEN)
            {
                ErrorMessage = "Parola trebuie sa aiba mai mult de 6 caractere.";
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Parola trebuie sa contina cel putin un o litera mica.";
                return false;
            }
            if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Parola trebuie sa contina cel putin un o litera mare.";
                return false;
            }
            if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Parola trebuie sa contina cel putin o cirfa.";
                return false;
            }
            if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Parola trebuie sa contina cel putin un caracter special. (de exemplu: ! @ # $ % ^ & * ( ) _ )";
                return false;
            }

            return true;
        }
    }
}
