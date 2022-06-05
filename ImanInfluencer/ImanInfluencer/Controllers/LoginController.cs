using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImanInfluencer.Controllers
{
    public class LoginController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LoginController(ModelContext _context, IWebHostEnvironment _hostEnvironment)
        {
            this._context = _context;
            this._hostEnvironment = _hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            const string id = "id";
            var Auth = _context.Userlogin1s.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            
            if (Auth != null)
            {
                var cartid = _context.Carts.FirstOrDefault(p => p.Userid == Auth.Userid);
                HttpContext.Session.SetInt32(id, (int)Auth.Userid.Value);
                switch (Auth.Roleid)
                {
                    case 1:
                        {
                            
                            HttpContext.Session.SetInt32("cartid", (int)cartid.Id);

                            return RedirectToAction("Index", "UserHome");
                        }
                    case null:


                        return RedirectToAction("Index", "Home", new { @id = id });

                    case 2:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.Userid.Value);
                            return RedirectToAction("Index", "Admin");
                        }
                    case 4:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.Userid.Value);
                            return RedirectToAction("Index", "Accountant");
                        }

                }
            }

            return View();
        }
    }
}
