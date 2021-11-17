﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Models
{
    [Table("Consumers")]
    public class Consumer
    {
        [Key]
        public int ConsumerId  { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
        
        
        [MaxLength(69)]
        public string Address { get; set; }
        [NotMapped]
        public virtual  ICollection<Order> Orders { get; set; }
    }
}
