using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Migrations;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly PlannerContext _context;

        public SpeakersController(PlannerContext context)
        {
            _context = context;
        }

        // GET: Speakers
        public async Task<IActionResult> Index()
        {
            var plannerContext = _context.Speaker.Include(s => s.Member).Include(s => s.Planner);
            return View(await plannerContext.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .Include(s => s.Member)
                .Include(s => s.Planner)
                .FirstOrDefaultAsync(m => m.SpeakerID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        public IActionResult Create()
        {
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName");
            ViewData["PlannerID"] = new SelectList(_context.Planner, "PlannerID", "Date");
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeakerID,PlannerID,MemberName,Topic")] Models.Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName", speaker.MemberName);
            ViewData["PlannerID"] = new SelectList(_context.Planner, "PlannerID", "Date", speaker.PlannerID);
            return View(speaker);
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName", speaker.MemberName);
            ViewData["PlannerID"] = new SelectList(_context.Planner, "PlannerID", "Date", speaker.PlannerID);
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpeakerID,PlannerID,MemberName,Topic")] Models.Speaker speaker)
        {
            if (id != speaker.SpeakerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.SpeakerID))
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
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName", speaker.MemberName);
            ViewData["PlannerID"] = new SelectList(_context.Planner, "PlannerID", "Date", speaker.PlannerID);
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .Include(s => s.Member)
                .Include(s => s.Planner)
                .FirstOrDefaultAsync(m => m.SpeakerID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speaker = await _context.Speaker.FindAsync(id);
            _context.Speaker.Remove(speaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.SpeakerID == id);
        }
    }
}
