using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Testimonial
    {
        public decimal Id { get; set; }
        public decimal? Userid { get; set; }
        public string Description { get; set; }
        public decimal? status { get; set; }

        public virtual User1 User { get; set; }
    }
}
