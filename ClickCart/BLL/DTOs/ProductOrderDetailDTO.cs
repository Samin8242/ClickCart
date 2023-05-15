using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductOrderDetailDTO
    {
        public List<ProductOrderDetailDTO> ProductOrderDetails { get; set; }

        public ProductOrderDetailDTO()
        {
            ProductOrderDetails = new List<ProductOrderDetailDTO>();
        }
    }
}
