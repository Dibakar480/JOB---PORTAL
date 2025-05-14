using JOB___PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace JOB___PORTAL.Controllers
{
    public class ProviderController : Controller
    {
        ProjectContext _db;
        public ProviderController(ProjectContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(Provider obj)
        {
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Provider obj)
        {
            var logincheck=_db.tblProvider.Where(a=>a.Email == obj.Email && a.Password==obj.Password).FirstOrDefault();
            if (logincheck == null)
            {
                ViewBag.Message = "Invalid Check Your Correct Passward & Email ID";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("useremailID", obj.Email);

                return RedirectToAction("Index","Jobs");
            }
        }
      
        [HttpGet]
        public IActionResult Registration()

        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Provider obj)
        {
            try
            {
                var emailcheck=_db.tblProvider.Where(a=>a.Email==obj.Email).FirstOrDefault();
                if (emailcheck!=null)
                {
                    TempData["Message"] = "Try Another Email ID";
                    return View(obj);
                }
                else
                {
                    _db.tblProvider.Add(obj);
                    _db.SaveChanges();
                    TempData["Message"] = "Registration Succsess";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
