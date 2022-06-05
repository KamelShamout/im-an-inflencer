using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImanInfluencer.Models
{
    public class Deductions
    {

        public decimal Id { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Amount { get; set; }

        public DateTime? Dateof { get; set; }
        public virtual User1 User { get; set; }
    }
}
