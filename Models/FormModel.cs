using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "Le champ nom est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ prénom est obligatoire")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ genre est obligatoire")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Le champ adresse est obligatoire")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le champ code postal est obligatoire")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Le champ ville est obligatoire")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Le champ email est obligatoire")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ date de début est obligatoire")]
        public DateTime? DateDebut { get; set; }

        [Required(ErrorMessage = "Le champ formation est obligatoire")]
        public string TypeFormation { get; set; }
        [Required(ErrorMessage = "Champ obligatoire, entrer N/E si non effectuée")]
        public string AvisCobol { get; set; }
        [Required(ErrorMessage = "Champ obligatoire, entrer N/E si non effectuée")]
        public string AvisCSharp { get; set; }
    }
}
