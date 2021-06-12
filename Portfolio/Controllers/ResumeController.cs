using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
using System.Web;

namespace Portfolio.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resume
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Resume.Include(r => r.ResumeCategory);
            Boolean? debug = true;
#if DEBUG
            debug = true;
#else
            debug = false;
#endif

            ViewData["DebugMode"] = debug;
            return View(await applicationDbContext.OrderBy(u=>u.Start).ToListAsync());
        }

        //// GET: Resume/Create
        public IActionResult Create()
        {
            ViewData["ResumeCategoryId"] = new SelectList(_context.ResumeCategory, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resume obj)
        {
            if (ModelState.IsValid)
            {
                await _context.Resume.AddAsync(obj);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //// GET: Resume/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }
            var resume =  await _context.Resume.FindAsync(id);

            if(resume == null)
            {
                return NotFound();
            }

            ViewData["ResumeCategoryId"] = new SelectList(_context.ResumeCategory, "Id", "Name", resume.ResumeCategoryId);
            return View(resume);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Resume resume)
        {
            if(resume == null)
            {
                return NotFound();
            }

             if (ModelState.IsValid)
            {
                _context.Update(resume);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeCategoryId"] = new SelectList(_context.ResumeCategory, "Id", "Name", resume.ResumeCategoryId);
            return View(resume);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var resume = await _context.Resume.FindAsync(id);

            _context.Resume.Remove(resume);
            await _context.SaveChangesAsync();

            //var applicationDbContext = _context.Resume.Include(r => r.ResumeCategory);
            //return View(await applicationDbContext.ToListAsync());
            return RedirectToAction(nameof(Index));
        }



        //// GET: Resume/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var resume = await _context.Resume
        //        .Include(r => r.ResumeCategory)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (resume == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(resume);
        //}

        //// POST: Resume/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var resume = await _context.Resume.FindAsync(id);
        //    _context.Resume.Remove(resume);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ResumeExists(int id)
        //{
        //    return _context.Resume.Any(e => e.Id == id);
        //}
    }
}
