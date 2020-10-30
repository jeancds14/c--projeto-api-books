using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class BookRent
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpectedDate { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
