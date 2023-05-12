using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string CartBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime DeletedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public Cart() { 
            CartItems = new List<CartItem>();
        
        
        }

    }
}
