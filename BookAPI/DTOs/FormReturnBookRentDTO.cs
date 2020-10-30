using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.DTOs
{
    public class FormReturnBookRentDTO
    {
        public int idBookRent { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
