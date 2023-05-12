using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        [ForeignKey("User")]
        public string ReviewBy { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
