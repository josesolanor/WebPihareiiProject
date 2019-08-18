using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPihare.Models;

namespace WebPihare.Library
{
    public class LUsuarios : ListObject
    {
        public LUsuarios()
        {

        }
        public LUsuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _usersRole = new UsersRoles();
        }
        public LUsuarios(RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _singInManager = signInManager;
            _usersRole = new UsersRoles();
        }

        internal async Task <object[]> userLogin(string userName, string password)
        {
            try
            {
                var result = await _singInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = _userManager.Users.Where(u => u.Email.Equals(userName)).ToList();
                    _userRoles = await _usersRole.getRole(_userManager, _roleManager, user[0].Id);
                    _userData = new UserData
                    {
                        Id = user[0].Id,
                        Role = _userRoles[0].Text,
                        UserName = user[0].UserName
                    };
                    code = "0";
                    description = result.Succeeded.ToString();
                }
                else
                {
                    code = "1";
                    description = "Correo o contraseña invalidas";
                }
            }
            catch (Exception ex)
            {
                code = "2";
                description = ex.Message;
            }
            _identityError = new IdentityError
            {
                Code = code,
                Description = description
            };
            object[] data = { _identityError, _userData };

            return data;
        }
    }
}
