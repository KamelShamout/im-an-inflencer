using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Category1
    {
        public Category1()
        {
            Product1s = new HashSet<Product1>();
        }

        public decimal Id { get; set; }
        public string Categoryname { get; set; }
        public string Imagepath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<Product1> Product1s { get; set; }
    }
}
