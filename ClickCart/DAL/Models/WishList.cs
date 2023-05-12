using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class WishList
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        public string WishBy { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
