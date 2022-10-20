using H4.Forms.Oef1.Models;
using H4.Forms.Oef1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace H4.Forms.Oef1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //login form
        [HttpGet]
        public IActionResult Login()
        {
            //create viewmodel
            var accountLoginViewModel
                = new AccountLoginViewModel();
            accountLoginViewModel.RememberMe
                = true;
            //pass the model to the view
            return View(accountLoginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLoginViewModel
            accountLoginViewModel)
        {
            //check validation
            //automatic validation using ModelState class
            if(ModelState.IsValid == false)
            {
                return View(accountLoginViewModel);
            }
            //check the credentials hardcoded
            //post-redirect-get principe
            if(accountLoginViewModel.Username == "mil@test.com"
                && accountLoginViewModel.Password == "test123")
            {
                return RedirectToAction("Success");
            }
            else
            {
                //wrong credentials
                ModelState.AddModelError("", "Wrong credentials!");
                return View(accountLoginViewModel);
            }
        }
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            AccountRegisterViewModel accountregisterViewModel
                = new();
            //populate list of Countries
            accountregisterViewModel
                .Countries = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "BE",
                        Text = "België",
                        Selected = true
                    },
                    new SelectListItem
                    {
                        Value = "NL",
                        Text = "Nederland",
                        
                    },
                    new SelectListItem
                    {
                        Value = "LU",
                        Text = "Luxemburg",
                    },
                };
            //populate list of checkboxes
            //with roles
            accountregisterViewModel
                .Roles =
                new List<CheckboxModel>
                {
                    new CheckboxModel
                    {
                        Value = 1,
                        Text = "Buyer",
                    },
                    new CheckboxModel
                    {
                        Value = 2,
                        Text = "Seller",
                    },
                    new CheckboxModel
                    {
                        Value = 3,
                        Text = "Sales Rep",
                    },
                };
            ViewBag.PageTitle = "register";
            return View(accountregisterViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountRegisterViewModel
            accountRegisterViewModel)
        {
            //check if passwords match
            //hardcoded
            var SelectedRoles = accountRegisterViewModel
                .Roles.Where(r => r.IsSelected == true);
            if(!ModelState.IsValid)
            {
                accountRegisterViewModel
                .Countries = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "BE",
                        Text = "België",
                        Selected = true
                    },
                    new SelectListItem
                    {
                        Value = "NL",
                        Text = "Nederland",

                    },
                    new SelectListItem
                    {
                        Value = "LU",
                        Text = "Luxemburg",
                    },
                };
                return View(accountRegisterViewModel);
            }
            return View();
        }

    }
}
