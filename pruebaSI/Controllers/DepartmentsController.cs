using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaSI.Data;
using pruebaSI.Models;

namespace pruebaSI.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartmentsController(ApplicationDbContext db)
        {
            this.db = db;


        }

        public async Task<IActionResult> Index(string search)
        {
            return View(await db.Departments.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var depart = await db.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department depart)
        {
            if (ModelState.IsValid)
            {
                db.Add(depart);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(depart);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var depart = await db.Departments.FindAsync(id);

            if ( depart == null)
            {
                return NotFound();
            }

            return View(depart);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Department depart)
        {
            if(id != depart.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(depart);
                    await db.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(depart);
        }public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await db.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var depart = await db.Departments.FindAsync(id);
            db.Departments.Remove(depart);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
        }

    }
}
