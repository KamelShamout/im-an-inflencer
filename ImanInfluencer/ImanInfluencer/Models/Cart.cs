using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Cartproducts = new HashSet<Cartproduct>();
        }

        public decimal Id { get; set; }
        public decimal? Userid { get; set; }

        public virtual User1 User { get; set; }
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
    }
}
