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

        internal async Task <object[]> userLogin(string email, string password, int commisionerid)
        {
            try
            {
                var userObtainedByEmail = await _userManager.FindByEmailAsync(email);

                if (userObtainedByEmail.Email.Equals(email))
                {
                    await _singInManager.SignInAsync(userObtainedByEmail, false);

                    var user = _userManager.Users.Where(u => u.Email.Equals(email)).ToList();
                    _userRoles = await _usersRole.getRole(_userManager, _roleManager, user[0].Id);
                    _userData = new UserData
                    {
                        Id = user[0].Id,
                        Role = _userRoles[0].Text,
                        UserName = user[0].UserName,
                        CommisionerId = commisionerid,
                    };
                    code = "0";
                    description = "True";
                }
                else
                {
                    code = "1";
                    description = "Usuario o contraseña invalidas";
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
