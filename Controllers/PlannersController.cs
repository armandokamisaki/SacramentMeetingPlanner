using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class PlannersController : Controller
    {
        private readonly PlannerContext _context;

        public PlannersController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Planners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planner.ToListAsync());
        }

        // GET: Planners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .FirstOrDefaultAsync(m => m.PlannerId == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // GET: Planners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlannerId,Date,Member1ID,Member2ID,Hymn1ID,Member3ID,Hymn2ID,Speaker1ID,Speaker2ID,Speaker3ID,SpecialHymn,Speaker4ID,Hymn3ID,Member4ID,Hymn4ID")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planner);
        }

        // GET: Planners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner.FindAsync(id);
            if (planner == null)
            {
                return NotFound();
            }
            return View(planner);
        }

        // POST: Planners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlannerId,Date,Member1ID,Member2ID,Hymn1ID,Member3ID,Hymn2ID,Speaker1ID,Speaker2ID,Speaker3ID,SpecialHymn,Speaker4ID,Hymn3ID,Member4ID,Hymn4ID")] Planner planner)
        {
            if (id != planner.PlannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlannerExists(planner.PlannerId))
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
            return View(planner);
        }

        // GET: Planners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .FirstOrDefaultAsync(m => m.PlannerId == id);
            if (planner == null)
            {
                return NotFound();
            }

            return View(planner);
        }

        // POST: Planners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planner = await _context.Planner.FindAsync(id);
            _context.Planner.Remove(planner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlannerExists(int id)
        {
            return _context.Planner.Any(e => e.PlannerId == id);
        }
    }
}
