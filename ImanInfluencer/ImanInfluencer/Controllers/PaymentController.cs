using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImanInfluencer.Models;
using Microsoft.AspNetCore.Http;

namespace Influencer.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ModelContext _context;
        string id = "id";

        public PaymentController(ModelContext context)
        {
            _context = context;
        }

        // GET: Payment
        public async Task<IActionResult> Index()
        {

            int userid = (int)HttpContext.Session.GetInt32(id);
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            var modelContext = _context.Payment1s.Include(p => p.User).Where(x => x.Userid == userid);
            return View(await modelContext.ToListAsync());
        }

        // GET: Payment/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment1 = await _context.Payment1s
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment1 == null)
            {
                return NotFound();
            }

            return View(payment1);
        }

        // GET: Payment/Create
        public IActionResult Create()
        {

            int userid = (int)HttpContext.Session.GetInt32(id);
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;

            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname");
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cardname,Userid,Amount")] Payment1 payment1)
        {
            if (ModelState.IsValid)
            {
                payment1.Userid = (int)HttpContext.Session.GetInt32("id");
                _context.Add(payment1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", payment1.Userid);
            return View(payment1);
        }

        // GET: Payment/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment1 = await _context.Payment1s.FindAsync(id);
            if (payment1 == null)
            {
                return NotFound();
            }
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", payment1.Userid);
            return View(payment1);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Cardname,Userid,Amount")] Payment1 payment1)
        {
            if (id != payment1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Payment1Exists(payment1.Id))
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
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", payment1.Userid);
            return View(payment1);
        }

        // GET: Payment/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment1 = await _context.Payment1s
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment1 == null)
            {
                return NotFound();
            }

            return View(payment1);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var payment1 = await _context.Payment1s.FindAsync(id);
            _context.Payment1s.Remove(payment1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Payment1Exists(decimal id)
        {
            return _context.Payment1s.Any(e => e.Id == id);
        }
    }
}
