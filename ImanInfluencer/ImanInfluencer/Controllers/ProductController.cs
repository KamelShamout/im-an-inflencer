using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Influencer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(ModelContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;


            var modelContext = _context.Product1s.Include(p => p.Category).Include(p => p.User).Include(p => p.Images).Where(x => x.Userid == userid && x.Status == 0);
            return View(await modelContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product1 == null)
            {
                return NotFound();
            }

            return View(product1);
        }

        // GET: Product/Create
        public IActionResult Create()
        {

            int? id = (int)HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                return NotFound();
            }
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            ViewBag.userid = id;
            ViewData["Categoryid"] = new SelectList(_context.Category1s, "Id", "Categoryname");
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname");


            return View();
        }

        [HttpPost]
        public IActionResult Testimonial(string description)
        {
            Testimonial temp = new Testimonial();
            temp.status = 0;
            temp.Description = description;
            temp.Userid = (int)HttpContext.Session.GetInt32("id");
            _context.Add(temp);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Status,Description,Userid,Imagepath,Categoryid,ImageFile")] Product1 product)
        {
            if (ModelState.IsValid)
            {
                product.Status = 0;
                product.Dateofup = DateTime.Today;
                product.Userid = (int)HttpContext.Session.GetInt32("id");
                _context.Add(product);
                await _context.SaveChangesAsync();
                var LastId = _context.Product1s.OrderByDescending(p => p.Id).FirstOrDefault().Id;
                foreach (var item in product.ImageFile)
                {
                    Image image = new Image();
                    image.Productid = LastId;
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string extension = Path.GetExtension(item.FileName);
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                        await item.CopyToAsync(fileStream);
                    image.Imagepath = fileName;
                    _context.Add(image);
                    await _context.SaveChangesAsync();

                }





                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Category1s, "Id", "Id", product.Categoryid);
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", product.Userid);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s.FindAsync(id);
            if (product1 == null)
            {
                return NotFound();
            }
            ViewData["Categoryid"] = new SelectList(_context.Category1s, "Id", "Id", product1.Categoryid);
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", product1.Userid);
            return View(product1);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name,Price,Status,Description,Userid,Imagepath,Categoryid")] Product1 product1)
        {
            if (id != product1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product1Exists(product1.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Category1s, "Id", "Id", product1.Categoryid);
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", product1.Userid);
            return View(product1);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product1 == null)
            {
                return NotFound();
            }

            return View(product1);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var product1 = await _context.Product1s.FindAsync(id);
            _context.Product1s.Remove(product1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product1Exists(decimal id)
        {
            return _context.Product1s.Any(e => e.Id == id);
        }
    }
}
