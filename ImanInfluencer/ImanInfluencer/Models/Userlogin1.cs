using System;
using System.Collections.Generic;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class Userlogin1
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Userid { get; set; }

        public virtual User1 User { get; set; }
    }
}
