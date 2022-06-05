using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Image
    {
        public decimal Id { get; set; }
        public string Imagename { get; set; }
        public string Imagepath { get; set; }
        public decimal? Productid { get; set; }

        public virtual Product1 Product { get; set; }
    }
}
