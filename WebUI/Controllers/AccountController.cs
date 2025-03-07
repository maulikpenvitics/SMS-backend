using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Data.Users;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        public readonly IUserService _userService = new UserService();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
       // [HttpPost]
        public ActionResult Login()
        {
            ViewData["IsLoginPage"] = true; // Mark it as login page
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.AccountViewModel model)
        {
            
            var user = _userService.GetUsers().ToList().FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                // Store the user ID in session
                Session["UserId"] = user.Id;

                // Redirect to the Index action of the Home controller
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If validation fails, set an error message
                ViewData["IsLoginPage"] = true;
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();  // Return the view with the error message
            }
        }
    }
}