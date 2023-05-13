using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
        public int? Price { get; set; }
        
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public int DiscountId { get; set; }
            
        public string SupplyBy { get; set; }
    }
}
