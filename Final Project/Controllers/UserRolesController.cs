using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;


namespace Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;


        public UserManager<ApplicationUser> _userManager { get; }

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }



        #region ShowAllUsers
        [HttpGet]
        public async Task<IActionResult> ViewUsers()
        {
            var users = await _userManager.Users.ToListAsync();


            var roles = _roleManager.Roles;
            ViewBag.Roles = roles;

            return View(users);
        }
        #endregion


        #region ChangeUserRole
        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var oldRole = _roleManager.Roles.FirstOrDefault(r => r.Id == user.RoleId);



            var newRole = _roleManager.Roles.FirstOrDefault(r => r.Id == roleId);

            await _userManager.RemoveFromRoleAsync(user, oldRole.Name);
            await _userManager.AddToRoleAsync(user, newRole.Name);

            user.RoleId = newRole.Id;
            await _userManager.UpdateAsync(user);



            return Ok();
        }
        #endregion


        #region DeleteUser

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);





            //Doesn't Work when RedirectToAction So...
            var users = await _userManager.Users.ToListAsync();
            var roles = _roleManager.Roles;
            ViewBag.Roles = roles;
            //end
            
            return View("ViewUsers",users);
        }
        #endregion


    }
}