﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            var planners = _context.Planner
            .Include(c => c.Member) 
            .Include(c => c.Hymn)
            .AsNoTracking();
            return View(await planners.ToListAsync());
            
        }

        // GET: Planners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
            .Include(c => c.Member)
            .Include(c => c.Hymn)
            .Include(s => s.Speakers)                  
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.PlannerID == id);            
            if (planner == null)
            {
                return NotFound();
            }
            

            return View(planner);
           
        }

        // GET: Planners/Create
        public IActionResult Create()
        {
            ViewData["HymnName"] = new SelectList(_context.Hymn, "HymnName", "HymnName");
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName");
            //PopulateMembersDropDownList();

            return View();
        }

       


        // POST: Planners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlannerID,Date,President,Conducting,OpeningHymn,Invocation,SacramentHymn,SpecialHymn,ClosingHymn,Benediction,DismissalSong")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planner);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Speakers");
            }
            //PopulateMembersDropDownList(planner.President);
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName");
            ViewData["HymnName"] = new SelectList(_context.Hymn, "HymnName", "HymnName");
            
            return View(planner);
        }
       

        // GET: Planners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planner = await _context.Planner
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PlannerID == id);            
            if (planner == null)
            {
                return NotFound();
            }
            //PopulateMembersDropDownList(planner.President);
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName");
            ViewData["HymnName"] = new SelectList(_context.Hymn, "HymnName", "HymnName");
            return View(planner);
        }

        // POST: Planners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlannerID,Date,President,Conducting,OpeningHymn,Invocation,SacramentHymn,SpecialHymn,ClosingHymn,Benediction,DismissalSong")] Migrations.Planner planner)
        {
            if (id != planner.PlannerID)
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
                    if (!PlannerExists(planner.PlannerID))
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
            //PopulateMembersDropDownList(planner.President);
            ViewData["FullName"] = new SelectList(_context.Member, "FullName", "FullName");
            ViewData["HymnName"] = new SelectList(_context.Hymn, "HymnName", "HymnName");
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
                .FirstOrDefaultAsync(m => m.PlannerID == id);
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

        private void PopulateMembersDropDownList(object selectedMember = null)
        {
            var membersQuery = from d in _context.Member
                                   orderby d.FirstName
                                   select d;
            ViewBag.FullName = new SelectList(membersQuery.AsNoTracking(), "FirstName", "FirstName", selectedMember);

            //var hymnsQuery = from e in _context.Hymn
                             //orderby e.HymnName
                             //select e;
            //ViewBag.HymnID = new SelectList(hymnsQuery.AsNoTracking(), "HymnId", "HymnName", selectedMember);

        }

        //private void PopulateHymnsDropDownList(object selectedHymn = null)
        //{
            //var hymnsQuery = from e in _context.Hymn
                             //orderby e.HymnName
                             //select e;
           // ViewBag.HymnID = new SelectList(hymnsQuery.AsNoTracking(), "HymnId", "HymnName", selectedHymn);
        //}

        private bool PlannerExists(int id)
        {
            return _context.Planner.Any(e => e.PlannerID == id);
        }
    }
}
