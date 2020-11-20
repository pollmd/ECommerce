using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Models
{
    public class Produs
    {
        [Key]
        public int id { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public float Cost { get; set; }
        public float Tva { get; set; }
        public float Acciz { get; set; }
        public string Marime { get; set; }
        public string Culoare { get; set; }
        public float Reducere { get; set; }
        public DateTime StartReducere { get; set; }
        public DateTime EndReducere { get; set; }
        public string Imagine { get; set; }
    }
}
