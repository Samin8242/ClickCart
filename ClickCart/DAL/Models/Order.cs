using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string OrderedBy { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [ForeignKey("Shipper")]
        public string DeliveryBy { get; set; }

        public virtual User User { get; set; }
        public virtual Shipper Shipper { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
            PaymentDetails = new List<PaymentDetail>();
        }


    }
}
