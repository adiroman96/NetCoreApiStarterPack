using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Extensions
{
    public static class SSNHelper
    {
        public static DateTime ExtractBirthDate(string CNP)
        {
            int y = 0, m, d;
            var charZero = 48;

            if ((CNP[0] - charZero) == 1 || (CNP[0] - charZero) == 2)
                y = 1900 + (CNP[1] - charZero) * 10 + (CNP[2] - charZero);
            if ((CNP[0] - charZero) == 3 || (CNP[0] - charZero) == 4)
                y = 1800 + (CNP[1] - charZero) * 10 + (CNP[2] - charZero);
            if ((CNP[0] - charZero) == 5 || (CNP[0] - charZero) == 6)
                y = 2000 + (CNP[1] - charZero) * 10 + (CNP[2] - charZero);
            if ((CNP[0] - charZero) == 7 || (CNP[0] - charZero) == 8)
            {
                y = (CNP[1] - charZero) * 10 + (CNP[2] - charZero);
                if (y <= 20)
                    y += 2000;
                else
                    y += 1900;
            }
            m = (CNP[3] - charZero) * 10 + (CNP[4] - charZero);
            d = (CNP[5] - charZero) * 10 + (CNP[6] - charZero);

            try
            {
                return new DateTime(y, m, d);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetAge(DateTime? birthdate)
        {
            if (birthdate == null)
            {
                return 0;
            }

            var bd = birthdate.Value;
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - bd.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (bd.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
