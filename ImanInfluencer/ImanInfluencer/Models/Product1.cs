using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Product1
    {
        public Product1()
        {
            Images = new HashSet<Image>();
            Transactions = new HashSet<Transaction>();
            Cartproducts = new HashSet<Cartproduct>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
 
        public decimal? Status { get; set; }
        public string Description { get; set; }
        public decimal? Userid { get; set; }
        public DateTime? Dateofup { get; set; }
        public decimal? Categoryid { get; set; }
        [NotMapped]
        public IFormFileCollection ImageFile { get; set; }
        public virtual Category1 Category { get; set; }
        public virtual User1 User { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }

    }
}
