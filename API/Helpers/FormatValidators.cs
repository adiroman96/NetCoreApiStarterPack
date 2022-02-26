using Models.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class FormatValidators
    {
        public static class UsernameValidation
        {
            public const string Regex = @"^[a-zA-Z0-9_\.]+$";
            public const string ErrorMessage = "Utilizatorul trebuie sa contina doar litere mici, litere mari, . si _";
        }

        public static class EmailValidation
        {
            public const string Regex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            public const string ErrorMessage = "Format gresit al adresei de email.";
        }

        public static class SSNValidation
        {
            public const string ErrorMessage = "CNP invalid!";
        }

        public static class CardNumberValdiation
        {
            public const string Regex = @"^[0-9]{16}$";
            public const string ErrorMessage = "Numarul de card trebuie sa contina exact 16 cifre.";
        }

        public static class PatientIdValidation
        {
            public const string Regex = @"^[0-9]+$";
            public const string ErrorMessage = "Id pacient trebuie sa contina doar cifre";
        }

        public class SSNFormatValidator : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                string CNP = Convert.ToString(value);
                var charZero = 48;
                if (CNP == null || CNP.Length == 0)
                {
                    ErrorMessage = "CNP NU poate sa aiba lungimea 0!";
                    return false;
                }

                if (CNP[0] - charZero == 9) //cetateni straini
                {
                    return true;
                }

                if (CNP.Length != 13)
                {
                    ErrorMessage = "Lungimea CNP trebuie sa fie 13!";
                    return false;
                }

                int s = (CNP[0] - charZero) * 2 + (CNP[1] - charZero) * 7 + (CNP[2] - charZero) * 9 + (CNP[3] - charZero) * 1 + (CNP[4] - charZero) * 4 + (CNP[5] - charZero) * 6 + (CNP[6] - charZero) * 3 + (CNP[7] - charZero) * 5 + (CNP[8] - charZero) * 8 + (CNP[9] - charZero) * 2 + (CNP[10] - charZero) * 7 + (CNP[11] - charZero) * 9;
                int rest = s % 11;

                if ((rest < 10 && (CNP[12] - charZero) == rest) || (rest == 10 && (CNP[12] - charZero) == 1))
                {
                    if (CNP.Equals("0000000000000"))
                    {
                        ErrorMessage = "CNP invalid!";
                        return false;
                    }

                    try
                    {
                        SSNHelper.ExtractBirthDate(CNP);
                    }
                    catch (Exception)
                    {
                        ErrorMessage = "CNP invalid!";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "CNP invalid!";
                    return false;
                }

                return true;
            }
        }

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
}
