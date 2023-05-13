using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class Order
    {
        public int Id { get; set; }
     
        public string OrderedBy { get; set; }
     
        public DateTime OrderDate { get; set; }
    
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        
        public string DeliveryBy { get; set; }
    }
}
