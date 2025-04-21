using Mart.Web.Models;
using Mart.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mart.Web.Controllers
{
    public class AccountController(UserManager<AccountUser> userManager,
                                    SignInManager<AccountUser> signInManager) : Controller
    {
        private readonly UserManager<AccountUser> _userManager = userManager;
        private readonly SignInManager<AccountUser> _signInManager = signInManager;
        public IActionResult Login()
        {
            LoginViewModel model = new();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var accountUser = await _userManager.FindByEmailAsync(loginViewModel.UserName);
            if (accountUser == null)
            {
                ModelState.AddModelError("UserName", "User name provided is not registered yet!");
                return View(loginViewModel);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(accountUser, loginViewModel.Password, false);
            if (result.Succeeded)
            {
                var claims = await _userManager.GetClaimsAsync(accountUser);
                if (claims != null && claims.Count > 0)
                {
                    var identity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    };
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal, properties);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("UserName", "This user is not having any access configured yet");
                    return View(loginViewModel);
                }
            }
            else
            {
                ModelState.AddModelError("Password", "Password provided is not correct!");
                return View(loginViewModel);
            }
        }
        public IActionResult CreateAccount()
        {
            CreateAccountViewModel model = new();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel createAccountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createAccountViewModel);
            }
            if (!createAccountViewModel.EmailId.Equals(createAccountViewModel.ConfirmEmailId))
            {
                ModelState.AddModelError("ConfirmEmailId", "Email Id and Confirm Email Id not matching");
                return View(createAccountViewModel);
            }
            if (!createAccountViewModel.Password.Equals(createAccountViewModel.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Password and Confirm Password not matching");
                return View(createAccountViewModel);
            }
            AccountUser accountUser = new()
            {
                FirstName = createAccountViewModel.FirstName,
                LastName = createAccountViewModel.LastName,
                Address = createAccountViewModel.Address,
                Email = createAccountViewModel.EmailId,
                UserName = createAccountViewModel.EmailId,
            };
            var accountCreation = await _userManager.CreateAsync(accountUser, createAccountViewModel.Password);
            if (accountCreation.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, accountUser.Id),
                    new (ClaimTypes.Name, accountUser.UserName),
                    new (ClaimTypes.Email, accountUser.Email),
                    new ("Role","Member")
                };
                var addClaimResult = await _userManager.AddClaimsAsync(accountUser, claims);
                if (addClaimResult.Succeeded)
                {
                    await _userManager.UpdateAsync(accountUser);
                }
            }
            return View("AccountCreationSuccessful");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
