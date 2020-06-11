using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App4.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App4.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Kayıt Hatası", error.Description);
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Giriş Hatası", "Kullanıcı bilgilerinden kaynaklı bir hata oluştu");
                }
            }
            else
            {
                ModelState.AddModelError("Varolmayan kullanıcı.", "Girdiğiniz bilgiler ile eşleşen kullanıcı bulunamadı");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult GoogleLogin(string returnUrl = "/")
        {
            string redirectUrl = Url.Action("ExternalResponse", "User", new { returnUrl = returnUrl });

            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

            return new ChallengeResult(GoogleDefaults.AuthenticationScheme, authenticationProperties);
        }

        public async Task<IActionResult> ExternalResponse(string returnUrl = "/")
        {
            ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();

            if (loginInfo == null)
            {
                return RedirectToAction("Login", "User");
            }

            var user = await _userManager.FindByEmailAsync(loginInfo.Principal.FindFirst(ClaimTypes.Email).Value);

            //kayıtlı kullanıcı için
            if (user != null)
            {
                await _signInManager.SignInAsync(user, true);
                return Redirect(returnUrl);
            }

            //Db de kaydı olmayan kullanıcı için yapılacak işlemler
            var signInResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                user = new IdentityUser
                {
                    Email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value
                };

                var identityResult = await _userManager.CreateAsync(user);

                if (identityResult.Succeeded)
                {
                    var loginResult = await _userManager.AddLoginAsync(user, loginInfo);
                    if (loginResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, true);
                    }
                }
            }
            return Redirect(returnUrl);
        }

        public IActionResult Denied()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult AssignRole()
        {
            var roles = _roleManager.Roles.ToList().Select(x => new SelectListItem()
            {
                Value = x.Name,
                Text = x.Name
            }).ToList();

            ViewBag.Roles = roles;

            var users = _userManager.Users.ToList().Select(x => new SelectListItem()
            {
                Text = x.Email,
                Value = x.Email
            }).ToList();

            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AssignRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _userManager.AddToRoleAsync(user, roleName);
            return RedirectToAction("Index", "Home");
        }
    }
}