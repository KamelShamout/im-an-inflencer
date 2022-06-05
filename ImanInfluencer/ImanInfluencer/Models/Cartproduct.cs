using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Cartproduct
    {
        public decimal Cartid { get; set; }
        public decimal Id { get; set; }

        public decimal? Productid { get; set; }


        public virtual Cart Cart { get; set; }
        public virtual Product1 Product { get; set; }

    }
}
