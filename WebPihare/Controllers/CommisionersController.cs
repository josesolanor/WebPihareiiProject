﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPihare.Entities;
using WebPihare.Core;
using WebPihare.Data;

namespace WebPihare.Controllers
{
    [Authorize]
    public class CommisionersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Hash _hash;

        public CommisionersController(ApplicationDbContext context, Hash hash)
        {
            _context = context;
            _hash = hash;
        }
        
        public async Task<IActionResult> Index()
        {
            var pihareiiContext = _context.Commisioner.Include(d => d.Role);
            return View(await pihareiiContext.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commisioner = await _context.Commisioner
                .FirstOrDefaultAsync(m => m.CommisionerId == id);
            if (commisioner == null)
            {
                return NotFound();
            }

            return View(commisioner);
        }

        public async Task<IActionResult> MyProfile()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(m => m.Type == "Id").Value);

            if (id == 0)
            {
                return NotFound();
            }

            var commisioner = await _context.Commisioner
                .FirstOrDefaultAsync(m => m.CommisionerId == id);
            if (commisioner == null)
            {
                return NotFound();
            }

            return View(commisioner);
        }

        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleValue");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Commisioner commisioner)
        {
            if (ModelState.IsValid)
            {
                commisioner.CommisionerPassword = _hash.EncryptString(commisioner.CommisionerPassword);
                _context.Add(commisioner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commisioner);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commisioner = await _context.Commisioner.FindAsync(id);
            if (commisioner == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleValue");
            return View(commisioner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Commisioner commisioner)
        {
            if (id != commisioner.CommisionerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    commisioner.CommisionerPassword = _hash.EncryptString(commisioner.CommisionerPassword);
                    _context.Update(commisioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommisionerExists(commisioner.CommisionerId))
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
            return View(commisioner);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commisioner = await _context.Commisioner
                .FirstOrDefaultAsync(m => m.CommisionerId == id);
            if (commisioner == null)
            {
                return NotFound();
            }

            return View(commisioner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commisioner = await _context.Commisioner.FindAsync(id);
            _context.Commisioner.Remove(commisioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommisionerExists(int id)
        {
            return _context.Commisioner.Any(e => e.CommisionerId == id);
        }
    }
}
