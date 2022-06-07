using Chatflix.dB;
using Chatflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chatflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Chatflix()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users Kullanici)
        {
            Db data = new Db();
            var _Kullanici = data.Users.FirstOrDefault(k => k.UserName == Kullanici.UserName && k.Password == Kullanici.Password);
            if (_Kullanici != null )
            {
                return RedirectToAction("Eslesmeler") ;
            }
            else
            {
                ViewBag.Message = "Kullanıcı Adı veya Şifre Hatalı";
               
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Register(Users Kullanici)
        {
            if (ModelState.IsValid)
            {
                Db data = new Db();
                var _Kullanici = data.Users.FirstOrDefault(k => k.UserName == Kullanici.UserName);
                if (_Kullanici != null)
                {
                    ViewBag.Message = "Bu Kullanıcı Adı Alınamaz";
                    
                }
                else
                {
                    data.Users.Add(Kullanici);
                    data.SaveChanges();
                    return RedirectToAction("Login");
                }
            }

            return View();

        }

        public IActionResult Eslesmeler()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
