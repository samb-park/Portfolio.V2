using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class WorkController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WorkController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Work
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Work.Include(w => w.WorkCategory);
            Boolean? debug = true;
#if DEBUG
            debug = true;
#else
            debug = false;
#endif

            ViewData["DebugMode"] = debug;
            return View(await applicationDbContext.OrderBy(u=>u.Start).ToListAsync());
        }

        // GET: Work/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .Include(w => w.WorkCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Work/Create
        public IActionResult Create()
        {
            ViewData["WorkId"] = new SelectList(_context.WorkCategory, "Id", "Name");
            return View();
        }

        // POST: Work/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Start,End,Image,WorkId,ShortDescription,skill")] Work work)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                string upload = webRootPath + WC.ImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetFileName(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                work.Image = fileName + extension;

                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkId"] = new SelectList(_context.WorkCategory, "Id", "Name", work.WorkId);
            return View(work);
        }

        // GET: Work/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            ViewData["WorkId"] = new SelectList(_context.WorkCategory, "Id", "Name", work.WorkId);
            return View(work);
        }

        // POST: Work/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Start,End,Image,WorkId,ShortDescription,skill")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    string webRootPath = _webHostEnvironment.WebRootPath;

                    var objFromDb = _context.Work.AsNoTracking().FirstOrDefault(u => u.Id == work.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetFileName(files[0].FileName);

                        var oldFile = Path.Combine(upload, objFromDb.Image);

                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        work.Image = fileName + extension;
                    }
                    else
                    {
                        work.Image = objFromDb.Image;
                    }

                    _context.Update(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.Id))
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
            ViewData["WorkId"] = new SelectList(_context.WorkCategory, "Id", "Name", work.WorkId);
            return View(work);
        }

        // GET: Work/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .Include(w => w.WorkCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var work = await _context.Work.FindAsync(id);


            string upload = _webHostEnvironment.WebRootPath + WC.ImagePath;

            var oldFile = Path.Combine(upload, work.Image);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            _context.Work.Remove(work);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.Id == id);
        }
    }
}
