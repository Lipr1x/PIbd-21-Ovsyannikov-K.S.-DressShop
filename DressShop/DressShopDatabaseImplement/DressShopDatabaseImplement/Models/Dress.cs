using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DressShopDatabaseImplement.Models
{
    public class Dress
    {
        public int Id { get; set; }
        [Required]
        public string DressName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("DressId")]
        public virtual List<DressComponent> DressComponents { get; set; }
        [ForeignKey("DressId")]
        public virtual List<Order> Orders { get; set; }
    }
}
