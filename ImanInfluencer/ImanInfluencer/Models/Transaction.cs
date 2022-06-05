using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Transaction
    {
        public decimal Id { get; set; }
        public decimal? Sellerid { get; set; }
        public decimal? Buyerid { get; set; }
        public decimal? Productid { get; set; }
        public DateTime? Actiondate { get; set; }
        public decimal? Status { get; set; }
        public decimal? Paymentid { get; set; }

        public virtual User1 Buyer { get; set; }
        public virtual Payment1 Payment { get; set; }
        public virtual Product1 Product { get; set; }
        public virtual User1 Seller { get; set; }
    }
}
