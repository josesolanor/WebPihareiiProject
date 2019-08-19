using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebPihare.Core;
using WebPihare.Data;
using WebPihare.Library;
using WebPihare.Models;

namespace WebPihare.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly Hash _hash;
        private LUsuarios _usuarios;
        private ListObject listObject = new ListObject();

        public LoginController(ApplicationDbContext context,
            Hash hash, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _hash = hash;
            _usuarios = new LUsuarios(roleManager, signInManager, userManager);
            listObject._singInManager = signInManager;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var encryptPassword = _hash.EncryptString(model.Input.Password);

                var commisionerLogin = _context.Commisioner.FirstOrDefault(v => v.Nic.Equals(model.Input.Username) && v.CommisionerPassword.Equals(encryptPassword));

                if (commisionerLogin is null)
                {
                    model.ErrorMessage = "Usuario o contraseña invalidas";
                    return View(model);
                }

                var listObject = await _usuarios.userLogin(commisionerLogin.Email, model.Input.Password, commisionerLogin.CommisionerId);
                var _identityError = (IdentityError)listObject[0];

                model.ErrorMessage = _identityError.Description;

                if (model.ErrorMessage.Equals("True"))
                {
                    var data = JsonConvert.SerializeObject(listObject[1]);
                    HttpContext.Session.SetString("User", data);
                    return RedirectToAction("Index", "Departments");
                }
                else
                {
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await listObject._singInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }
    }
}