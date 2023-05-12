using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Gender { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public User()
        {
            PaymentDetails = new List<PaymentDetail>();
            Carts= new List<Cart>();
            Reviews= new List<Review>();
            Orders= new List<Order>();
            WishLists= new List<WishList>();
        }

    }
}
