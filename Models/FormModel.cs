using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required, RegularExpression(@"^\d{5}$", ErrorMessage = "Code postal sur 5 chiffres.")]
        public string CodePostal { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required, EmailAddress(ErrorMessage = "Email invalide.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateDebut { get; set; }

        [Required]
        public string TypeFormation { get; set; }

        public string AvisCobol { get; set; }
        public string AvisCSharp { get; set; }
    }
}
