using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        public string NameOfRestaurant { get; set; }

        public string Location { get; set; }

        public string Cuisine { get; set; }
        [NotMapped]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
