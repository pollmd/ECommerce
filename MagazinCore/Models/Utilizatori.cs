using MagazinCore.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MagazinCore.Models
{
    public class Utilizatori
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu!")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie!")]
        public string Parola { get; set; }
        public DateTime Creare { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public UserRole Role { get; set; }
    }
}
