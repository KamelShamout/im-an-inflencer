using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImanInfluencer.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly ModelContext _context;

        public UserHomeController(ModelContext context)
        {
            _context = context;
            

        }

        public IActionResult Index()
        {


            var temp = _context.Testimonials.Include(p => p.User).Where(x => x.status == 1); ;
            var model3 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Testimonial>>(_context.Category1s.ToList(), temp);
            return View(model3);
        }

        public IActionResult Shop(string categoryname, string productname)
        {
            List<string> categoriesname = new List<string>();
            categoriesname.Add("All");
            foreach (var item in _context.Category1s)
            {
                categoriesname.Add(item.Categoryname);
            }
            ViewData["Categoryid"] = categoriesname;
            var userid = (int)HttpContext.Session.GetInt32("id");
            var categories = _context.Category1s.ToList();
            if (categoryname == null || productname == null)
            {
                var products2 = _context.Product1s.Include(p => p.Category).Include(p => p.Images).Where(x => x.Status == 0 && x.Userid != userid).ToList();
                var model32 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Product1>>(categories, products2);
                return View(model32);

            }
            if (categoryname == "All")
            {
                var products1 = _context.Product1s.Include(p => p.Category).Include(p => p.Images).Where(x => x.Status == 0 && x.Name.ToUpper().Contains(productname.ToUpper()) && x.Userid != userid).ToList();
                var model31 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Product1>>(categories, products1);
                return View(model31);
            }


            var products = _context.Product1s.Include(p => p.Category).Include(p => p.Images).Where(x => x.Status == 0 && x.Name.Contains(productname) && x.Userid != userid).ToList();
            var model3 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Category1>, IEnumerable<ImanInfluencer.Models.Product1>>(categories, products.Where(x => x.Category.Categoryname.ToUpper() == categoryname.ToUpper() && x.Name.ToUpper().Contains(productname.ToUpper())));
            return View(model3);
        }

        [HttpPost]
        public Product1 ProductImages(int id)
        {
            var product = _context.Product1s.Include(p => p.Images).FirstOrDefault(x => x.Id == id);

            return product;
        }

        [HttpPost]
        public int AddtoCart(int id)
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            User1 user = _context.User1s.Include(p => p.Carts).FirstOrDefault(x => x.Id == userid);
            
            Cartproduct product = new Cartproduct();
            product.Cartid = user.Carts.FirstOrDefault().Id;
            product.Productid = id;
            _context.Add(product);
             _context.SaveChangesAsync();
            return 1;
        }

        public IActionResult ProductDetail(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Product1s.Include(p => p.Images).Include(p => p.User).FirstOrDefault(x => x.Id == id);
            int userid = (int)HttpContext.Session.GetInt32("id");

            ViewData["Paymentid"] = new SelectList(_context.Payment1s.Where(x => x.Userid == userid), "Id", "Cardname");
            ViewBag.categoryname = _context.Category1s.FirstOrDefault(x => x.Id == product.Categoryid).Categoryname;

            var products = _context.Product1s.Include(p => p.Images).Where(p => p.Categoryid == product.Categoryid && p.Status == 0 && p.Id != id);
            var model1 = Tuple.Create<ImanInfluencer.Models.Product1, IEnumerable<ImanInfluencer.Models.Product1>>(product, products);
            return View(model1);
        }

    
        
        public IActionResult Cart()
        {
            int cartid = (int)HttpContext.Session.GetInt32("cartid");
            var cartproducts = _context.Cartproducts.Include(p => p.Product).Include(p => p.Product.Images).Where(x => x.Cartid == cartid);
            return View(cartproducts);
        }

        [HttpPost]
        public int Delete(int id)
        {
            Cartproduct product = _context.Cartproducts.FirstOrDefault(x => x.Id == id);
            _context.Cartproducts.Remove(product);
             _context.SaveChangesAsync();
            return 1;
        }



        [HttpPost]
        public int AddItem(int sellerid, int productid, int payment)
        {
            int buyerid = (int)HttpContext.Session.GetInt32("id");
            var validation = _context.Transactions.FirstOrDefault(x => x.Buyerid == buyerid && x.Productid == productid);
            var budget = _context.Payment1s.FirstOrDefault(x => x.Id == payment);
            var product = _context.Product1s.FirstOrDefault(x => x.Id == productid);
            if (validation != null)
            {
                return 0;
            }
            if (budget.Amount < product.Price)
            {
                return 2;
            }
            var tax = _context.Payment1s.FirstOrDefault(x => x.Cardname == "products");
            tax.Amount += product.Price * 20 / 100;
            budget.Amount = budget.Amount - product.Price + (product.Price * 20/100);
            Transaction transaction = new Transaction();
            transaction.Productid = productid;
            transaction.Buyerid = buyerid;
            transaction.Sellerid = sellerid;
            transaction.Status = 0;
            transaction.Paymentid = payment;
            _context.Add(transaction);
            _context.Update(budget);
            _context.Update(tax);

            _context.SaveChangesAsync();
            return 1;
        }
    }
}
