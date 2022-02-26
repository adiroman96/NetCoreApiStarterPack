using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public static class ErrorMessage
    {
        public const string RoleMappingIsMandatory = "Tipul contului este obligatoriu. Tipul contului trebuie sa fie un numar.";
        public const string SSNIsMandatory = "CNP-ul e obligatoriu.";
        public const string FirstNameIsMandatory = "Prenumele e obligatoriu";
        public const string LasNameIsMandatory = "Numele e obligatoriu";
        public const string UsernmaeIsMandatory = "Numele de utilizator e obligatoriu";
        public const string UsernameCantHaveSpaces = "Numele de utilizator nu poate avea spatii.";
        public const string EnterTheUsername = "Introduceti numele de utilizator ales la crearea contului.";
        public const string PasswordIsMandatory = "Parola e obligatorie";
        public const string PasswordLength = "Parola trebuie sa aiba cel putin 6 caractere";
        public const string PasswordsDontMatch = "Cele doua parole nu se ptrivesc";
        public const string EmailIsMandatory = "Email-ul nu are formatul corespunzator";
        public const string AccountNotAllowedToAccesMedicalData = "Contul al carui date medicale incercati sa le accesati nu exista sau nu aveti acces. Daca sunteti doctor, asigurati-va ca sunteti conectat si ca pacientul v-a permis accesul. Daca incercati sa va accesati propriul dosar, reconectati-va.";
        public const string DataNotFound = "Nu s-au gasit date care sa corespunda cu parametrii alesi.";
        public const string IdIsAPositiveNumber = "Id-ul trebuie sa fie o valoare pozitiva.";
        public const string RestrictedAccess = "Acces restrictionat.";
        public const string Forbidden = "Acces restrictionat.";
        public const string PleaseLogin = "Acces restrictionat. Pentru acces trebuie sa va autentificati.";
        public const string RoleNotFoundORNotAllowed = "Nu exista rolul pe care incercati sa il stergeti sau nu aveti acest drept.";
        public const string NullReferencePrefix = "NullReferenceException: ";


        // -------- appointments ------
        public const string PhoneIsMandatory = "Numarul de telefon e obligatoriu.";
        public const string OrganizationIDIsMandatory = "ID-ul unitatii medicale e obligatoriu.";
        public const string DepartmentIDIsMandatory = "ID-ul departamentului e obligatoriu.";
        public const string DoctorIDIsMandatory = "ID-ul doctorului e obligatoriu.";
        public const string AppointmentIDIsMandatory = "ID-ul programatii e obligatoriu.";
        public const string DateIsMandatory = "Data e obligatorie.";
        public const string MessageIsMandatory = "Mesajul e obligatoriu.";

        public static string FieldMissing(string fieldName, params string[] fields)
        {
            if (fields != null && fields.Length > 0)
            {
                var response = $"Campurile urmatoare trebuie completate: <b>{fieldName}</b> ";
                for (int i = 0; i < fields.Length; i++)
                {
                    response += $", <b>{fields[i]}</b>";
                }
                return response;
            }
            return $"Campul <b>{fieldName}</b> trebuie completat.";
        }

        public static string FillAtLeastOne(params string[] fields)
        {
            if (fields != null && fields.Length > 0)
            {
                var response = $"Cel putin unul din urmatoarele trebuie completate: <b>{fields[0]}</b> ";
                for (int i = 1; i < fields.Length; i++)
                {
                    response += $", <b>{fields[i]}</b>";
                }
                return response;
            }
            return "";
        }
    }
}
