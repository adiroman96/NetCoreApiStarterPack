using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class MedicalInformation : BaseEntity
    {
        [Required]
        [MinLength(length: 5, ErrorMessage = "Descrierea trebuie sa aiba minim 5 caracter")]
        public string Title { get; set; }

        [MaxLength(length: 2, ErrorMessage = "Descrierea trebuie sa aiba maxim 2 caractere")]
        [MinLength(length: 1, ErrorMessage = "Descrierea trebuie sa aiba minim 1 caracter")]
        public string Description { get; set; }

        public long? AccountID { get; set; } = null;
    }
}
