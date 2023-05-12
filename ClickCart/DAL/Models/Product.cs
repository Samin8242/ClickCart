using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int? Price { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Discount")]
        public int DiscountId { get; set; }

        [ForeignKey("Supplier")]
        public string SupplyBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public Product()
        {
            OrderDetails = new List<OrderDetail>();
            Reviews= new List<Review>();
            WishLists= new List<WishList>();
            CartItems= new List<CartItem>();

        }

    }
}
