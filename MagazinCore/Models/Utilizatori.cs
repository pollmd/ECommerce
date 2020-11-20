using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Models
{
    public class Utilizatori
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Parola { get; set; }
        public DateTime Creare { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
