using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductWishDTO
    {
        public List<WishListDTO> WishLists { get; set; }

        public ProductWishDTO()
        {
            WishLists = new List<WishListDTO>();
        }
    }
}
