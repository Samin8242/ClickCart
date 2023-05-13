using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PaymentDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string PaymentBy { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
