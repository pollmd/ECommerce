using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Models
{
    public class Cos
    {
        [Key]
        public int Id { get; set; }
        public DateTime Creare { get; set; }
        public string Status { get; set; }

        [ForeignKey("Utilizatori")]
        public int UserId { get; set; }
        public Utilizatori Utilizator { get; set; }

    }
}
