using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
       
        public string CartBy { get; set; }
       
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
