using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImanInfluencer.Models
{
    public class DeductionsController : Controller
    {
        private readonly ModelContext _context;

        public DeductionsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Deductions
        public async Task<IActionResult> Index()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            var modelContext = _context.Deductions.Include(d => d.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Deductions/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deductions = await _context.Deductions
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deductions == null)
            {
                return NotFound();
            }

            return View(deductions);
        }

        // GET: Deductions/Create
        public IActionResult Create()
        {
            int userid = (int)HttpContext.Session.GetInt32("id");
            var username = _context.User1s.FirstOrDefault(x => x.Id == userid).Fname;
            var useravatar = _context.User1s.FirstOrDefault(x => x.Id == userid).Imagepath;
            ViewBag.username = username;
            ViewBag.useravatar = useravatar;
            ViewData["Userid"] = new SelectList(_context.User1s.Where(x => x.Jobtitle != null), "Id", "Fname");
            return View();
        }

        // POST: Deductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Userid,Amount,Dateof")] Deductions deductions)
        {
            if (ModelState.IsValid)
            {
                deductions.Dateof = DateTime.Today;
                _context.Add(deductions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", deductions.Userid);
            return View(deductions);
        }

        // GET: Deductions/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deductions = await _context.Deductions.FindAsync(id);
            if (deductions == null)
            {
                return NotFound();
            }
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", deductions.Userid);
            return View(deductions);
        }

        // POST: Deductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Userid,Amount")] Deductions deductions)
        {
            if (id != deductions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deductions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeductionsExists(deductions.Id))
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
            ViewData["Userid"] = new SelectList(_context.User1s, "Id", "Fname", deductions.Userid);
            return View(deductions);
        }

        // GET: Deductions/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deductions = await _context.Deductions
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deductions == null)
            {
                return NotFound();
            }

            return View(deductions);
        }

        // POST: Deductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var deductions = await _context.Deductions.FindAsync(id);
            _context.Deductions.Remove(deductions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeductionsExists(decimal id)
        {
            return _context.Deductions.Any(e => e.Id == id);
        }
    }
}
