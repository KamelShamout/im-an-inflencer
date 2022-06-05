using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ImanInfluencer.Controllers
{
    public class UserController : Controller
    {
        private readonly ModelContext _context;
        private IWebHostEnvironment _hostEnvironment;

        public UserController(ModelContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnvironment = hostEnviroment;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.User1s.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fname,Lname,Age,Phone,Email,Imagepath,ImageFile")] User1 user, string username, string password)
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
                login1.Roleid = 1;
                login1.Password = password;
                login1.Username = username;
                login1.Userid = LastId;
                _context.Add(login1);
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s.FindAsync(id);
            if (user1 == null)
            {
                return NotFound();
            }
            return View(user1);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Fname,Lname,Age,Phone,Email,Imagepath,Dateofreg")] User1 user1)
        {
            if (id != user1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User1Exists(user1.Id))
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
            return View(user1);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var user1 = await _context.User1s.FindAsync(id);
            _context.User1s.Remove(user1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User1Exists(decimal id)
        {
            return _context.User1s.Any(e => e.Id == id);
        }
    }
}
