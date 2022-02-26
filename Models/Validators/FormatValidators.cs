using Models.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.Validators
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
    }
}
