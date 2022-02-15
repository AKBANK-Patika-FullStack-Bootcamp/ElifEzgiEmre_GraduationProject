using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Data.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FlatId { get; set; }
        [ForeignKey("FlatId")]
        public virtual Flat Flat { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool OdendiMi { get; set; }
        public int BillTypeId { get; set; }
        [ForeignKey("BillTypeId")]
        public virtual BillType BillType { get; set; }
    }
}
