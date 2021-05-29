using Dashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (user!=null)
            {
                if (user.Login(user))
                {
                    //add session
                    HttpContext.Session.SetString("username", user.username);
                    HttpContext.Session.SetString("password", user.password);
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    TempData["Error"] = "Usuário ou senha incorretos";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
