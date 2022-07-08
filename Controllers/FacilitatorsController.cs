using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App2.Models;

namespace App2.Controllers
{
    public class FacilitatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacilitatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Facilitators
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.facilitator.Include(f => f.department).Include(f => f.position);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Facilitators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.facilitator
                .Include(f => f.department)
                .Include(f => f.position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return View(facilitator);
        }

        // GET: Facilitators/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id");
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id");
            return View();
        }

        // POST: Facilitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Surname,PrinterCode,DepartmentId,PositionId")] Facilitator facilitator)
        {
            
                _context.Add(facilitator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id", facilitator.DepartmentId);
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id", facilitator.PositionId);
            return View(facilitator);
        }

        // GET: Facilitators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.facilitator.FindAsync(id);
            if (facilitator == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id", facilitator.DepartmentId);
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id", facilitator.PositionId);
            return View(facilitator);
        }

        // POST: Facilitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Surname,PrinterCode,DepartmentId,PositionId")] Facilitator facilitator)
        {
            if (id != facilitator.Id)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(facilitator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitatorExists(facilitator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id", facilitator.DepartmentId);
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id", facilitator.PositionId);
            return View(facilitator);
        }

        // GET: Facilitators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.facilitator
                .Include(f => f.department)
                .Include(f => f.position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return View(facilitator);
        }

        // POST: Facilitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.facilitator == null)
            {
                return Problem("Entity set 'ApplicationDbContext.facilitator'  is null.");
            }
            var facilitator = await _context.facilitator.FindAsync(id);
            if (facilitator != null)
            {
                _context.facilitator.Remove(facilitator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitatorExists(int id)
        {
          return (_context.facilitator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
