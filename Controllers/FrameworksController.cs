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
    public class FrameworksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrameworksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Frameworks
        public async Task<IActionResult> Index()
        {
            //Check if _context is null
            if (_context.Frameworks == null)
            {
                return NotFound();
            }
            return View(await _context.Frameworks.ToListAsync());
        }

        // GET: Frameworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Frameworks == null)
            {
                return NotFound();
            }

            var frameworkModel = await _context.Frameworks
                .FirstOrDefaultAsync(m => m.FrameworkId == id);
            if (frameworkModel == null)
            {
                return NotFound();
            }

            return View(frameworkModel);
        }

        // GET: Frameworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frameworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrameworkId,Name,Description")] FrameworkModel frameworkModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frameworkModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frameworkModel);
        }

        // GET: Frameworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Frameworks == null)
            {
                return NotFound();
            }

            var frameworkModel = await _context.Frameworks.FindAsync(id);
            if (frameworkModel == null)
            {
                return NotFound();
            }
            return View(frameworkModel);
        }

        // POST: Frameworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrameworkId,Name,Description")] FrameworkModel frameworkModel)
        {
            if (id != frameworkModel.FrameworkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frameworkModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrameworkModelExists(frameworkModel.FrameworkId))
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
            return View(frameworkModel);
        }

        // GET: Frameworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Frameworks == null)
            {
                return NotFound();
            }

            var frameworkModel = await _context.Frameworks
                .FirstOrDefaultAsync(m => m.FrameworkId == id);
            if (frameworkModel == null)
            {
                return NotFound();
            }

            return View(frameworkModel);
        }

        // POST: Frameworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Check if _context is null
            if (_context.Frameworks == null)
            {
                return NotFound();
            }
            var frameworkModel = await _context.Frameworks.FindAsync(id);
            if (frameworkModel != null)
            {
                _context.Frameworks.Remove(frameworkModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrameworkModelExists(int id)
        {
            //Check if _context is null
            if (_context.Frameworks == null)
            {
                return false;
            }
            return _context.Frameworks.Any(e => e.FrameworkId == id);
        }
    }
}
