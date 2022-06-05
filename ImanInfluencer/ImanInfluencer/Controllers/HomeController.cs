using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImanInfluencer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ImanInfluencer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;

        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            var temp = _context.Testimonials.Include(p => p.User).Where(x => x.status == 1); ;
            var model3 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Testimonial>>(_context.Category1s.ToList(), temp);
            return View(model3);
        }

        public IActionResult Shop(string categoryname,string productname)
        {

            List<string> categoriesname = new List<string>();
            categoriesname.Add("All");
            foreach(var item in _context.Category1s)
            {
                categoriesname.Add(item.Categoryname);
            }
            ViewData["Categoryid"] = categoriesname;

            var categories = _context.Category1s.ToList();
           
            if(categoryname == null || productname == null)
            {
                var products2 = _context.Product1s.Include(p => p.Category).Include(p => p.Images).Where(x => x.Status == 0).ToList();
                var model32 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Product1>>(categories, products2);
                return View(model32);

            }
            if(categoryname == "All")
            {
                var products1 = _context.Product1s.Include(p => p.Category).Include(p => p.Images).Where(x => x.Status == 0 && x.Name.ToUpper().Contains(productname.ToUpper())).ToList();
                var model31 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Product1>>(categories, products1);
                return View(model31);
            }

           
                var products = _context.Product1s.Include(p => p.Category).Include(p => p.Images).Where(x => x.Status == 0 && x.Name.Contains(productname)).ToList();
                var model3 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Product1>>(categories, products.Where(x => x.Category.Categoryname.ToUpper() == categoryname.ToUpper() && x.Name.ToUpper().Contains(productname.ToUpper())));
                return View(model3);
            


        }

        [HttpPost]
        public Product1 ProductImages(int id)
        {
            var product = _context.Product1s.Include(p => p.Images).FirstOrDefault(x => x.Id == id);
            
            return product;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
