using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DressShopDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int WorkingTime { get; set; }

        [Required]
        public int PauseTime { get; set; }

        [ForeignKey("ImplementerId")]
        public List<Order> Orders { get; set; }
    }
}
