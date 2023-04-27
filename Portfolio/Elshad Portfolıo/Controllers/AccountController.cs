using Elshad_Portfolıo.ViewModels;
using JobBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Elshad_Portfolıo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //#region Create_Super_Admin
        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser SuperAdmin = new AppUser
        //    {
        //        Email = "sv.elshad@gmail.com",
        //        UserName = "SuperAdmin",
        //        FullName = "Elshad Sadıgov",
        //    };
        //    var result = await userManager.CreateAsync(SuperAdmin, "E16091995s");
        //    return Ok(SuperAdmin);
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    await roleManager.CreateAsync(role1);
        //    return Ok("Created Roles");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser user = await userManager.FindByEmailAsync("sv.elshad@gmail.com");
        //    await userManager.AddToRoleAsync(user, "SuperAdmin");
        //    return Ok("Add Role");
        //}
        //#endregion


        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser member = await userManager.FindByEmailAsync(loginVM.Email);
            if (member == null)
            {
                ModelState.AddModelError("", "Email or Password invalid");
                return View();
            }
          
            var result = await signInManager.PasswordSignInAsync(member, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password invalid");
                return View();
            }
            return RedirectToAction ( "Index","home");
        }
        #endregion



        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
