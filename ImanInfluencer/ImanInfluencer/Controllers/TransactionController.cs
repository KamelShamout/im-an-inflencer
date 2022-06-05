using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Influencer.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ModelContext _context;

        public TransactionController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuyingRequest()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            var items = _context.Transactions.Include(p => p.Payment).Include(p => p.Product).Include(p => p.Product.Images).Where(x => x.Buyerid == userid && x.Status == 0);
            return View(items);
        }

        public IActionResult SellingRequest()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar; var items = _context.Transactions.Include(p => p.Buyer).Include(p => p.Buyer.Userlogin1s).Include(p => p.Product).Include(p => p.Product.Images).Where(x => x.Sellerid == userid && x.Status == 0);
            return View(items);
        }

        [HttpPost]
        public IActionResult Delete(decimal id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.Id == id);
            var payment = _context.Payment1s.FirstOrDefault(x => x.Id == transaction.Paymentid);
            var product = _context.Product1s.FirstOrDefault(x => x.Id == transaction.Productid);
            var tax = _context.Payment1s.FirstOrDefault(x => x.Cardname == "products");
            tax.Amount -= product.Price * 20 / 100;
            payment.Amount = payment.Amount + product.Price;
            _context.Transactions.Remove(transaction);
            _context.Update(payment);
            _context.Update(tax);

            _context.SaveChangesAsync();
            return RedirectToAction(nameof(BuyingRequest));
        }

        [HttpPost]
        public IActionResult Accept(decimal id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.Id == id);
            transaction.Status = 1;
            transaction.Actiondate = DateTime.Today;
            var product = _context.Product1s.FirstOrDefault(x => x.Id == transaction.Productid);
            product.Status = 1;
            var temp = _context.Transactions.Where(x => x.Id != transaction.Id && x.Buyerid == transaction.Buyerid && x.Productid == product.Id);
            _context.Transactions.RemoveRange(temp);
            _context.Update(transaction);
            _context.Update(product);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(SellingRequest));
        }

        public IActionResult BoughtProduct()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            var items = _context.Transactions.Include(p => p.Payment).Include(p => p.Product).Include(p => p.Product.Images).Where(x => x.Buyerid == userid && x.Status == 1);
            return View(items);

        }

        public IActionResult SoldProduct()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            var items = _context.Transactions.Include(p => p.Buyer).Include(p => p.Buyer.Userlogin1s).Include(p => p.Product).Include(p => p.Product.Images).Where(x => x.Sellerid == userid && x.Status == 1);
            return View(items);

        }
    }
}
