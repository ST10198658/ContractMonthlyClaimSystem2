using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractMonthlyClaimSystem.Data;
using ContractMonthlyClaimSystem.Models;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ClaimApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClaimApplications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClaimApplications.Include(c => c.ClaimType).Include(c => c.Lecturer).Include(c => c.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClaimApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimApplication = await _context.ClaimApplications
                .Include(c => c.ClaimType)
                .Include(c => c.Lecturer)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claimApplication == null)
            {
                return NotFound();
            }

            return View(claimApplication);
        }

        // GET: ClaimApplications/Create
        public IActionResult Create()
        {
            ViewData["ClaimTypeId"] = new SelectList(_context.ClaimTypes, "Id", "Description");
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "FullName");
            ViewData["StatusId"] = new SelectList(_context.SystemCodesDetails, "Id", "Description");
            return View();
        }

        // POST: ClaimApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ClaimApplication claimApplication)
        {
            var pendingStatus = _context.SystemCodesDetails.Include(x => x.SystemCodes).Where(y => y.Code == "Pending" && y.SystemCodes.Code=="ClaimApprovalStatus").FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                claimApplication.CreatedOn = DateTime.Now;
                claimApplication.CreatedById = "Kamogelo";
                ;

                _context.Add(claimApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClaimTypeId"] = new SelectList(_context.ClaimTypes, "Id", "Description", claimApplication.ClaimTypeId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "FullName", claimApplication.LecturerId);
            ViewData["StatusId"] = new SelectList(_context.SystemCodesDetails, "Id", "Description", claimApplication.StatusId);
            return View(claimApplication);
        }

        // GET: ClaimApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimApplication = await _context.ClaimApplications.FindAsync(id);
            if (claimApplication == null)
            {
                return NotFound();
            }
            ViewData["ClaimTypeId"] = new SelectList(_context.ClaimTypes, "Id", "Description", claimApplication.ClaimTypeId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "FullName", claimApplication.LecturerId);
            ViewData["StatusId"] = new SelectList(_context.SystemCodesDetails, "Id", "Description", claimApplication.StatusId);
            return View(claimApplication);
        }

        // POST: ClaimApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ClaimApplication claimApplication)
        {
            if (id != claimApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    claimApplication.ModifiedOn = DateTime.Now;
                    claimApplication.ModifiedById = "Kamogelo";
                    _context.Update(claimApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimApplicationExists(claimApplication.Id))
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
            ViewData["ClaimTypeId"] = new SelectList(_context.ClaimTypes, "Id", "Description", claimApplication.ClaimTypeId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "Id", "FullName", claimApplication.LecturerId);
            ViewData["StatusId"] = new SelectList(_context.SystemCodesDetails, "Id", "Description", claimApplication.StatusId);
            return View(claimApplication);
        }

        // GET: ClaimApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimApplication = await _context.ClaimApplications
                .Include(c => c.ClaimType)
                .Include(c => c.Lecturer)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claimApplication == null)
            {
                return NotFound();
            }

            return View(claimApplication);
        }

        // POST: ClaimApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claimApplication = await _context.ClaimApplications.FindAsync(id);
            if (claimApplication != null)
            {
                _context.ClaimApplications.Remove(claimApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimApplicationExists(int id)
        {
            return _context.ClaimApplications.Any(e => e.Id == id);
        }
    }
}
