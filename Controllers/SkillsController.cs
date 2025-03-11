using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioDT191G.Data;
using PortfolioDT191G.Models;

namespace PortfolioDT191G.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }
            return View(await _context.Skills.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skillModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.SkillId == id);
            if (skillModel == null)
            {
                return NotFound();
            }

            return View(skillModel);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillId,Name")] SkillModel skillModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillModel);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skillModel = await _context.Skills.FindAsync(id);
            if (skillModel == null)
            {
                return NotFound();
            }
            return View(skillModel);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillId,Name")] SkillModel skillModel)
        {
            if (id != skillModel.SkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillModelExists(skillModel.SkillId))
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
            return View(skillModel);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skillModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.SkillId == id);
            if (skillModel == null)
            {
                return NotFound();
            }

            return View(skillModel);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }
            var skillModel = await _context.Skills.FindAsync(id);
            if (skillModel != null)
            {
                _context.Skills.Remove(skillModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillModelExists(int id)
        {
            //Check if _context is null
            if (_context.Skills == null)
            {
                return false;
            }
            return _context.Skills.Any(e => e.SkillId == id);
        }
    }
}
