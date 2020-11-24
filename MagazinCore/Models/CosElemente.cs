using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagazinCore.Models
{
    public class CosElemente
    {
        [Key]
        public int Id { get; set; }
        public int Cantitate { get; set; }

        [ForeignKey("Cos")]
        public int CosId { get; set; }
        public Cos Cos { get; set; }

        [ForeignKey("Produs")]
        public int ProdusId { get; set; }
        public Produs Produs { get; set; }
    }
}
