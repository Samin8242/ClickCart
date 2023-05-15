using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserPaymentDTO
    {
        public List<PaymentDetailDTO> PaymentDetails { get; set; }

        public UserPaymentDTO()
        {
            PaymentDetails = new List<PaymentDetailDTO>();
        }
    }
}
