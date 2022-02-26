using Models.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Validators
{
    public class SSNFormatValidator : ValidationAttribute
    {
        public string ErrorMessage { get; private set; }

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
}
