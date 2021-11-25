using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNet_Dukcapil_CRUD.Models;

namespace ASPNet_Dukcapil_CRUD
{
    public class DukcapilsController : Controller
    {
        private readonly DatabaseContext _context;

        public DukcapilsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Dukcapils
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Dukcapils.Include(d => d.Marital).Include(d => d.Religion);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Dukcapils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dukcapil = await _context.Dukcapils
                .Include(d => d.Marital)
                .Include(d => d.Religion)
                .FirstOrDefaultAsync(m => m.DukcapilID == id);
            if (dukcapil == null)
            {
                return NotFound();
            }

            return View(dukcapil);
        }

        // GET: Dukcapils/Create
        public IActionResult Create()
        {
            ViewData["MaritalID"] = new SelectList(_context.Maritals, "MaritalID", "MaritalDesc");
            ViewData["ReligionID"] = new SelectList(_context.Religions, "ReligionID", "ReligionName");
            return View();
        }

        // POST: Dukcapils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DukcapilID,NIK,Name,MaidenName,BrithDate,Gender,ReligionID,MaritalID")] Dukcapil dukcapil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dukcapil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaritalID"] = new SelectList(_context.Maritals, "MaritalID", "MaritalDesc", dukcapil.MaritalID);
            ViewData["ReligionID"] = new SelectList(_context.Religions, "ReligionID", "ReligionName", dukcapil.ReligionID);
            return View(dukcapil);
        }

        // GET: Dukcapils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dukcapil = await _context.Dukcapils.FindAsync(id);
            if (dukcapil == null)
            {
                return NotFound();
            }
            ViewData["MaritalID"] = new SelectList(_context.Maritals, "MaritalID", "MaritalDesc", dukcapil.MaritalID);
            ViewData["ReligionID"] = new SelectList(_context.Religions, "ReligionID", "ReligionName", dukcapil.ReligionID);
            return View(dukcapil);
        }

        // POST: Dukcapils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DukcapilID,NIK,Name,MaidenName,BrithDate,Gender,ReligionID,MaritalID")] Dukcapil dukcapil)
        {
            if (id != dukcapil.DukcapilID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dukcapil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DukcapilExists(dukcapil.DukcapilID))
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
            ViewData["MaritalID"] = new SelectList(_context.Maritals, "MaritalID", "MaritalDesc", dukcapil.MaritalID);
            ViewData["ReligionID"] = new SelectList(_context.Religions, "ReligionID", "ReligionName", dukcapil.ReligionID);
            return View(dukcapil);
        }

        // GET: Dukcapils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dukcapil = await _context.Dukcapils
                .Include(d => d.Marital)
                .Include(d => d.Religion)
                .FirstOrDefaultAsync(m => m.DukcapilID == id);
            if (dukcapil == null)
            {
                return NotFound();
            }

            return View(dukcapil);
        }

        // POST: Dukcapils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dukcapil = await _context.Dukcapils.FindAsync(id);
            _context.Dukcapils.Remove(dukcapil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DukcapilExists(int id)
        {
            return _context.Dukcapils.Any(e => e.DukcapilID == id);
        }
    }
}
