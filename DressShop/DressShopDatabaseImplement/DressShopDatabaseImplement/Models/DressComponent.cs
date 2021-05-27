using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DressShopDatabaseImplement.Models
{
    public class DressComponent
    {
        public int Id { get; set; }
        public int DressId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Dress Dress { get; set; }
    }
}
