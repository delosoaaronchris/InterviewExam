using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewExam.Data;
using InterviewExam.Models;

namespace InterviewExam.Controllers
{
    public class RecyclableTypesController : Controller
    {
        private readonly InterviewExamContext _context;

        public RecyclableTypesController(InterviewExamContext context)
        {
            _context = context;
        }

        // GET: RecyclableTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecyclableType.ToListAsync());
        }

        // GET: RecyclableTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclableType = await _context.RecyclableType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recyclableType == null)
            {
                return NotFound();
            }

            return View(recyclableType);
        }

        // GET: RecyclableTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecyclableTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Rate,MinKg,MaxKg")] RecyclableType recyclableType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recyclableType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recyclableType);
        }

        // GET: RecyclableTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclableType = await _context.RecyclableType.FindAsync(id);
            if (recyclableType == null)
            {
                return NotFound();
            }
            return View(recyclableType);
        }

        // POST: RecyclableTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Rate,MinKg,MaxKg")] RecyclableType recyclableType)
        {
            if (id != recyclableType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recyclableType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecyclableTypeExists(recyclableType.Id))
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
            return View(recyclableType);
        }

        // GET: RecyclableTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclableType = await _context.RecyclableType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recyclableType == null)
            {
                return NotFound();
            }

            return View(recyclableType);
        }

        // POST: RecyclableTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recyclableType = await _context.RecyclableType.FindAsync(id);
            if (recyclableType != null)
            {
                _context.RecyclableType.Remove(recyclableType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecyclableTypeExists(int id)
        {
            return _context.RecyclableType.Any(e => e.Id == id);
        }
    }
}
