using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class User1
    {
        public User1()
        {
            Carts = new HashSet<Cart>();
            Payment1s = new HashSet<Payment1>();
            Product1s = new HashSet<Product1>();
            Testimonials = new HashSet<Testimonial>();
            TransactionBuyers = new HashSet<Transaction>();
            TransactionSellers = new HashSet<Transaction>();
            Userlogin1s = new HashSet<Userlogin1>();
            Deductions = new HashSet<Deductions>();
        }

        public decimal Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public decimal Age { get; set; }
        public decimal? Phone { get; set; }
        public string Email { get; set; }
        public string Imagepath { get; set; }
        public decimal? Salary { get; set; }
        public string Jobtitle { get; set; }
        public DateTime? Dateofreg { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Payment1> Payment1s { get; set; }
        public virtual ICollection<Product1> Product1s { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Transaction> TransactionBuyers { get; set; }
        public virtual ICollection<Transaction> TransactionSellers { get; set; }
        public virtual ICollection<Userlogin1> Userlogin1s { get; set; }
        public virtual ICollection<Deductions> Deductions { get; set; }

    }
}
