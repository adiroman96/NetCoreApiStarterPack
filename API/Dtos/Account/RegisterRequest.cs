using API.Helpers;
using Models;
using Models.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Account
{
    public class RegisterRequest
    {
        /// <summary>
        /// Root-ul linkului trimis pe mail pentru a verifica adresa de email. La acest string se va concatena pe server tokenul.
        /// </summary>
        /// <example>www.portal.ro/verificareemail?token=</example>
        public string urlToVerifyEmail { get; set; }

        // verification
        [Required(ErrorMessage = ErrorMessage.RoleMappingIsMandatory)]
        public int roleMapping { get; set; }

        private string _code = null;
        [RegularExpression(FormatValidators.PatientIdValidation.Regex, ErrorMessage = FormatValidators.PatientIdValidation.ErrorMessage)]
        public string code
        {
            get
            {
                return _code.NullSafeTrim();
            }
            set
            {
                _code = value.NullSafeTrim();
            }
        }

        private string _licenceNumber = null;
        public string licenceNumber
        {
            get
            {
                return _licenceNumber.NullSafeTrim();
            }
            set
            {
                _licenceNumber = value.NullSafeTrim();
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Valoarea specifica organizatiei trebuie sa fie un numar pozitiv.")]
        public int? organization { get; set; }

        // person
        private string _ssn;
        [Required(ErrorMessage = ErrorMessage.SSNIsMandatory)]
        [FormatValidators.SSNFormatValidator]
        public string ssn
        {
            get { return _ssn.NullSafeTrim(); }
            set { _ssn = value.NullSafeTrim(); }
        }

        private string _firstName;
        [Required(ErrorMessage = ErrorMessage.FirstNameIsMandatory)]
        public string firstName
        {

            get
            {
                return _firstName.ToTrimmedTitleCase();
            }
            set
            {
                _firstName = value.ToTrimmedTitleCase();
            }
        }

        private string _lastName;
        [Required(ErrorMessage = ErrorMessage.LasNameIsMandatory)]
        public string lastName
        {

            get
            {
                return _lastName.ToTrimmedTitleCase();
            }
            set
            {
                _lastName = value.ToTrimmedTitleCase();
            }
        }

        public DateTime createdAt { get; set; } = DateTime.Now;

        // account
        private string _username;
        [Required(ErrorMessage = "Numele de utilizator e obligatoriu")]
        [RegularExpression(FormatValidators.UsernameValidation.Regex, ErrorMessage = FormatValidators.UsernameValidation.ErrorMessage)]
        public string username
        {
            get { return _username.ToTrimmedLowerCase(); }
            set { _username = value.ToTrimmedLowerCase(); }
        }

        private string _password;
        [Required(ErrorMessage = "Parola e obligatorie")]
        [FormatValidators.NewPasswordFormatValidator]
        public string password
        {
            get
            {
                return _password.NullSafeTrim();
            }
            set
            {
                _password = value.NullSafeTrim();
            }
        }

        [Required(ErrorMessage = "Va rugam sa confirmati parola")]
        [Compare("password", ErrorMessage = "Cele doua parole nu se potrivesc")]
        public string confirmPassword { get; set; }


        private string _email;
        [Required(ErrorMessage = FormatValidators.EmailValidation.ErrorMessage)]
        [EmailAddress(ErrorMessage = FormatValidators.EmailValidation.ErrorMessage)]
        public string email
        {

            get
            {
                return _email.NullSafeTrim();
            }
            set
            {
                _email = value.NullSafeTrim();
            }
        }

        [Required(ErrorMessage = "Va rugam sa confirmati adresa de email")]
        [Compare("email", ErrorMessage = "Campurile de email nu se potrivesc")]
        public string confirmEmail { get; set; }

        private string _phone;
        public string phone
        {

            get
            {
                return _phone.NullSafeTrim();
            }
            set
            {
                _phone = value.NullSafeTrim();
            }
        }

        private string _city;
        public string city
        {
            get
            {
                return _city.ToTrimmedTitleCase();
            }
            set
            {
                _city = value.ToTrimmedTitleCase();
            }
        }

        private string _county;
        public string county
        {

            get
            {
                return _county.ToTrimmedTitleCase();
            }
            set
            {
                _county = value.ToTrimmedTitleCase();
            }
        }

        private string _speciality;
        public string speciality
        {

            get
            {
                return _speciality.ToTrimmedTitleCase();
            }
            set
            {
                _speciality = value.ToTrimmedTitleCase();
            }
        }
    }
}
