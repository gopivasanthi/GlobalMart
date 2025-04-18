using Mart.Web.Models;
using Mart.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mart.Web.Controllers
{
    public class AccountController(UserManager<AccountUser> userManager) : Controller
    {
        private readonly UserManager<AccountUser> _userManager = userManager;
        public IActionResult Login()
        {
            LoginViewModel model = new ();
            return View(model);
        }
        public IActionResult CreateAccount()
        {
            CreateAccountViewModel model = new();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateAccount(CreateAccountViewModel createAccountViewModel)
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

            _userManager.CreateAsync(accountUser, createAccountViewModel.Password);
            return View("AccountCreationSuccessful");
        }

    }
}
