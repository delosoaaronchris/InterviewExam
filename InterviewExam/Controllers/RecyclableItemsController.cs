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
    public class RecyclableItemsController : Controller
    {
        private readonly InterviewExamContext _context;

        public RecyclableItemsController(InterviewExamContext context)
        {
            _context = context;
        }

        // GET: RecyclableItems
        public async Task<IActionResult> Index()
        {
            var interviewExamContext = _context.RecyclableItem.Include(r => r.RecyclableType);
            return View(await interviewExamContext.ToListAsync());
        }

        // GET: RecyclableItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclableItem = await _context.RecyclableItem
                .Include(r => r.RecyclableType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recyclableItem == null)
            {
                return NotFound();
            }

            return View(recyclableItem);
        }

        // GET: RecyclableItems/Create
        public IActionResult Create()
        {
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableType, "Id", "Type");
            return View();
        }

        // POST: RecyclableItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecyclableTypeId,Weight,ComputedRate,ItemDescription")] RecyclableItem recyclableItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recyclableItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableType, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        // GET: RecyclableItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclableItem = await _context.RecyclableItem.FindAsync(id);
            if (recyclableItem == null)
            {
                return NotFound();
            }
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableType, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        // POST: RecyclableItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecyclableTypeId,Weight,ComputedRate,ItemDescription")] RecyclableItem recyclableItem)
        {
            if (id != recyclableItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recyclableItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecyclableItemExists(recyclableItem.Id))
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
            ViewData["RecyclableTypeId"] = new SelectList(_context.RecyclableType, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        // GET: RecyclableItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclableItem = await _context.RecyclableItem
                .Include(r => r.RecyclableType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recyclableItem == null)
            {
                return NotFound();
            }

            return View(recyclableItem);
        }

        // POST: RecyclableItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recyclableItem = await _context.RecyclableItem.FindAsync(id);
            if (recyclableItem != null)
            {
                _context.RecyclableItem.Remove(recyclableItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecyclableItemExists(int id)
        {
            return _context.RecyclableItem.Any(e => e.Id == id);
        }
    }
}
