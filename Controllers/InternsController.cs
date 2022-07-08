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
    public class InternsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InternsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.intern.Include(i => i.department).Include(i => i.position);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.intern == null)
            {
                return NotFound();
            }

            var intern = await _context.intern
                .Include(i => i.department)
                .Include(i => i.position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intern == null)
            {
                return NotFound();
            }

            return View(intern);
        }

        // GET: Interns/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id");
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id");
            return View();
        }

        // POST: Interns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,DeviceCode,InstitutionName,Graduated,GraduationYear,isWorkIntegratedLearning,DepartmentId,PositionId")] Intern intern)
        {
           
                _context.Add(intern);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id", intern.DepartmentId);
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id", intern.PositionId);
            return View(intern);
        }

        // GET: Interns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.intern == null)
            {
                return NotFound();
            }

            var intern = await _context.intern.FindAsync(id);
            if (intern == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id", intern.DepartmentId);
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id", intern.PositionId);
            return View(intern);
        }

        // POST: Interns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,DeviceCode,InstitutionName,Graduated,GraduationYear,isWorkIntegratedLearning,DepartmentId,PositionId")] Intern intern)
        {
            if (id != intern.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(intern);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternExists(intern.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["DepartmentId"] = new SelectList(_context.department, "Id", "Id", intern.DepartmentId);
            ViewData["PositionId"] = new SelectList(_context.position, "Id", "Id", intern.PositionId);
            return View(intern);
        }

        // GET: Interns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.intern == null)
            {
                return NotFound();
            }

            var intern = await _context.intern
                .Include(i => i.department)
                .Include(i => i.position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intern == null)
            {
                return NotFound();
            }

            return View(intern);
        }

        // POST: Interns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.intern == null)
            {
                return Problem("Entity set 'ApplicationDbContext.intern'  is null.");
            }
            var intern = await _context.intern.FindAsync(id);
            if (intern != null)
            {
                _context.intern.Remove(intern);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternExists(int id)
        {
          return (_context.intern?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
