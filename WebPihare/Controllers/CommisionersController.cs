using System;
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
using Microsoft.AspNetCore.Identity;
using WebPihare.Library;
using Microsoft.AspNetCore.Http;
using WebPihare.Models;
using Newtonsoft.Json;

namespace WebPihare.Controllers
{
    [Authorize]
    public class CommisionersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Hash _hash;
        private LUsuarios _usuarios;
        private ListObject listObject = new ListObject();

        public CommisionersController(ApplicationDbContext context, Hash hash, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _hash = hash;
            _usuarios = new LUsuarios(roleManager, signInManager, userManager);
            listObject._singInManager = signInManager;
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
            var user = HttpContext.Session.GetString("User");
            UserData dataItem = JsonConvert.DeserializeObject<UserData>(user.ToString());
            var id = dataItem.CommisionerId;

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
                var commisionerUser = new IdentityUser {
                    Email = commisioner.Email,
                    UserName = commisioner.Nic                    
                };

                try
                {
                    commisioner.CommisionerPassword = _hash.EncryptString(commisioner.CommisionerPassword);
                    _context.Add(commisioner);
                    await _context.SaveChangesAsync();

                    await _usuarios._userManager.CreateAsync(commisionerUser, commisioner.CommisionerPassword);
                    var RoleName = _context.Role.FirstOrDefault(v => v.RoleId.Equals(commisioner.RoleId)).RoleValue;
                    var addRoleToUser = await _usuarios._userManager.FindByEmailAsync(commisioner.Email);
                    await _usuarios._userManager.AddToRoleAsync(addRoleToUser, RoleName);
                }
                catch (Exception)
                {
                    return View(commisioner);
                }
                                
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

                    if (string.IsNullOrEmpty(commisioner.CommisionerPassword) && string.IsNullOrWhiteSpace(commisioner.CommisionerPassword))
                    {

                        var dataCommisioner = _context.Commisioner.FirstOrDefault(v => v.CommisionerId.Equals(id));
                        commisioner.CommisionerPassword = dataCommisioner.CommisionerPassword;
                    }

                    var user = HttpContext.Session.GetString("User");
                    UserData dataItem = JsonConvert.DeserializeObject<UserData>(user.ToString());

                    var userObtainedById = await _usuarios._userManager.FindByIdAsync(dataItem.Id);

                    await _usuarios._userManager.ChangePasswordAsync(userObtainedById, userObtainedById.PasswordHash, commisioner.CommisionerPassword);

                    userObtainedById.Email = commisioner.Email;
                    userObtainedById.NormalizedEmail = commisioner.Email.ToUpper();

                    commisioner.CommisionerPassword = _hash.EncryptString(commisioner.CommisionerPassword);
                    _context.Update(commisioner);
                    _context.Update(userObtainedById);
                 
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
