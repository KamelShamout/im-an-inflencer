using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Payment1
    {
        public Payment1()
        {
            Transactions = new HashSet<Transaction>();
        }

        public decimal Id { get; set; }
        public string Cardname { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Amount { get; set; }

        public virtual User1 User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
