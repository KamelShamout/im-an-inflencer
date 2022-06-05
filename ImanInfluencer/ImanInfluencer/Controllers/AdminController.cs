using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImanInfluencer.Controllers
{
    public class AdminController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(ModelContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            ViewBag.countofusers = _context.Userlogin1s.Where(x => x.Roleid == 1).ToList().Count;
            ViewBag.countofemployees = _context.Userlogin1s.Where(x => x.Roleid == 3).ToList().Count;
            ViewBag.countofproducts = _context.Product1s.ToList().Count;

            var mod = _context.Transactions.Include(p => p.Product);

            var users = _context.Userlogin1s.Include(p => p.User).ToList();
            var model3 = Tuple.Create<IEnumerable<ImanInfluencer.Models.Userlogin1>, IEnumerable<ImanInfluencer.Models.Transaction>, IEnumerable<ImanInfluencer.Models.Product1>>(users, mod,_context.Product1s);
            return View(model3);
        }

        public IActionResult Products(string datefrom, string dateto)
        {
            if(datefrom != null && dateto != null)
            {
                DateTime dfrom = Convert.ToDateTime(datefrom);
                DateTime dto = Convert.ToDateTime(dateto);

                var modelContext1 = _context.Transactions.Include(p => p.Product).Include(p => p.Product.Images).Where(x => DateTime.Compare(dfrom,x.Actiondate?? DateTime.Now) < 1 && DateTime.Compare(x.Actiondate ?? DateTime.Now, dto) < 1);
                
                return View(modelContext1);

            }
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;


            var modelContext = _context.Transactions.Include(p => p.Product).Include(p => p.Product.Images).Where(x =>  x.Status == 1);
            return View( modelContext);
        }



        public IActionResult Create()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fname,Lname,Age,Phone,Email,Imagepath,ImageFile,Jobtitle,Salary")] User1 user, string username, string password)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                string extension = Path.GetExtension(user.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await user.ImageFile.CopyToAsync(fileStream);
                }
                user.Imagepath = fileName;
                user.Dateofreg = DateTime.Today;
                _context.Add(user);

                await _context.SaveChangesAsync();
                var LastId = _context.User1s.OrderByDescending(p => p.Id).FirstOrDefault().Id;
                Cart cart = new Cart();
                cart.Userid = LastId;
                Userlogin1 login1 = new Models.Userlogin1();
                login1.Roleid = 3;
                login1.Password = password;
                login1.Username = username;
                login1.Userid = LastId;
                _context.Add(login1);
                _context.Add(cart);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Admin"); ;
            }
            return View(user);
        }




        public IActionResult ProductsMonthReport(string month)
        {
            int year = DateTime.Today.Year;
            int month1 = int.Parse(month);
            List<Product1> products = _context.Product1s.Include(p => p.Category).Include(p => p.User.Userlogin1s).Where(x => x.Dateofup.Value.Year == year && x.Dateofup.Value.Month == month1 ).ToList();
            var builder = new StringBuilder();
            builder.AppendLine("product name,Category, Price,Owner,Date of Upload,Status");
            foreach(var item in products)
            {
                string status = item.Status == 0? "Not sold" : "Sold";
                builder.AppendLine($"{item.Name},{item.Category.Categoryname},{item.Price},{item.User.Userlogin1s.FirstOrDefault().Username},{item.Dateofup},{status}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()),"text/csv","products.csv");
        }


        public IActionResult ProductsAnnualReport()
        {
            int year = DateTime.Today.Year;
            List<Product1> products = _context.Product1s.Include(p => p.Category).Include(p => p.User.Userlogin1s).Where(x => x.Dateofup.Value.Year == year ).ToList();
            var builder = new StringBuilder();
            builder.AppendLine("product name,Category, Price,Owner,Date of Upload,Status");
            foreach (var item in products)
            {
                string status = item.Status == 0 ? "Not sold" : "Sold";
                builder.AppendLine($"{item.Name},{item.Category.Categoryname},{item.Price},{item.User.Userlogin1s.FirstOrDefault().Username},{item.Dateofup},{status}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "AnnualProducts.csv");
        }







        public IActionResult CostReport()
        {

            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            var emp = _context.User1s.Include(p => p.Deductions).Where(x => x.Jobtitle != null);
            var paymnet = _context.Payment1s.FirstOrDefault(x => x.Cardname == "products");
            ViewBag.profits = paymnet.Amount;
            return View(emp);
        }





        public IActionResult EmpMonthReport(string month)
        {
            int year = DateTime.Today.Year;
            int month1 = int.Parse(month);
            List<User1> emp = _context.User1s.Include(p => p.Deductions.Where(r => r.Dateof.Value.Year == year && r.Dateof.Value.Month == month1)).Where(x => x.Jobtitle != null).ToList();
            var builder = new StringBuilder();
            builder.AppendLine("First name,Last name, Salary,Deductions,Dateofhiraing");
            double total = 0.0;
            double totalsalary = 0.0;
            double productsprofit = (double)_context.Payment1s.FirstOrDefault(x => x.Cardname == "products").Amount;
            foreach (var item in emp)
            {
                double sum = 0.0;
                foreach(var item2 in item.Deductions)
                {
                    sum = sum + (double)item2.Amount;
                }
                total += sum;
                totalsalary += (double)item.Salary;
                builder.AppendLine($"{item.Fname},{item.Lname},{item.Salary},{sum},{item.Dateofreg}");
            }
            builder.AppendLine($"total salary,{totalsalary},totaldeduction,{total},products profits,{productsprofit},total profit/loss,{(total+productsprofit)- totalsalary}");

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "CostReport.csv");
        }


        public IActionResult EmpAnnualReport()
        {
            int year = DateTime.Today.Year;
            List<User1> emp = _context.User1s.Include(p => p.Deductions.Where(r => r.Dateof.Value.Year == year)).Where(x => x.Jobtitle != null).ToList();
            var builder = new StringBuilder();
            builder.AppendLine("First name,Last name, Salary,Deductions,Dateofhiraing");
            double total = 0.0;
            double totalsalary = 0.0;
            double productsprofit = (double)_context.Payment1s.FirstOrDefault(x => x.Cardname == "products").Amount;
            foreach (var item in emp)
            {
                double sum = 0.0;
                
                foreach (var item2 in item.Deductions)
                {
                    sum = sum + (double)item2.Amount;
                }
                total += sum;
                totalsalary += (double)item.Salary;

                builder.AppendLine($"{item.Fname},{item.Lname},{item.Salary},{sum},{item.Dateofreg}");
            }
            builder.AppendLine($"total salary,{totalsalary},totaldeduction,{total},products profits,{productsprofit},total profit/loss,{  (total + productsprofit)- totalsalary}");
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "AnnualReport.csv");
        }




        public IActionResult Testimonial()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            return View(_context.Testimonials.Include(p => p.User).ToList());
        }



        [HttpPost]
        public IActionResult Delete(decimal id)
        {
          var temp =  _context.Testimonials.FirstOrDefault(x => x.Id == id);
            temp.status = 0;
            _context.Update(temp);

            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Testimonial));
        }

        [HttpPost]
        public IActionResult Accept(decimal id)
        {
            var temp = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            temp.status = 1;
            _context.Update(temp);

            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Testimonial));
        }
    }


    
}


