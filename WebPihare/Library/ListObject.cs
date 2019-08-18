using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPihare.Models;

namespace WebPihare.Library
{
    public class ListObject
    {
        public String description, code;

        public UserData _userData;
        public UsersRoles _usersRole;
        public IdentityError _identityError;

        public List<SelectListItem> _userRoles;

        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _singInManager;

        public List<object[]> dataList = new List<object[]>();

    }
}
