using MagazinCore.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinCore.Models
{
    public class Cos
    {
        [Key]
        public int Id { get; set; }
        public DateTime Creare { get; set; }
        public OrderStatus Status { get; set; }

        [ForeignKey("Utilizatori")]
        public int UserId { get; set; }
        public Utilizatori Utilizator { get; set; }

    }
}
