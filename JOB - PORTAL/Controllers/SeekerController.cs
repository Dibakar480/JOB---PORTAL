using JOB___PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Permissions;

namespace JOB___PORTAL.Controllers
{
    public class SeekerController : Controller
    {
        ProjectContext _db;
        IWebHostEnvironment _env;

        public SeekerController(ProjectContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index(string? searchText)
        {
            var Joblist = _db.tblJobs.Where(a => a.LastApplyDate > System.DateTime.Now).ToList();
            if (searchText != null)
            {
                Joblist = _db.tblJobs.Where(a => a.Company_Name.Contains(searchText) || a.SkillsRequired.Contains(searchText) ||
                a.Location.Contains(searchText)).ToList();
                ViewBag.SearchText = searchText;
                if (Joblist.Count == 0)
                {
                    ViewBag.Message = "No Record Found";
                }
            }
            return View(Joblist);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Seeker obj)
        {
            var LoginCheck = _db.tblSeeker.Where(a => a.Email == obj.Email && a.Password == obj.Password).FirstOrDefault();
            if (LoginCheck == null)
            {
                ViewBag.Message = "Enter Your Currect Email ID & Passward";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("useremailID", obj.Email);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Your_Profile()
        {
            string email = HttpContext.Session.GetString("useremailID");
            if (email == null)
            {
                TempData["Message"] = "Invalid";
                return View("Login");
            }
            else
            {
                var userseeker = _db.tblSeeker.Where(a => a.Email == email).FirstOrDefault();
                return View(userseeker);
            }
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Seeker obj)
        {
            try
            {
                var useremailcheck = _db.tblSeeker.Where(a => a.Email == obj.Email).FirstOrDefault();
                if (useremailcheck != null)
                {
                    TempData["Message"] = "Email already exists. Please use a different email.";
                    return View(obj);
                }
                else
                {
                    if (obj.SeekerProfilePicPath != null)
                    {
                        obj.SeekerProfilePic = UploadSeekerProfilePic(obj.SeekerProfilePicPath);
                    }
                    if (obj.SeekerCVFilePath != null)
                    {
                        obj.SeekerCVFile = UploadSeekerCVfilepath(obj.SeekerCVFilePath);
                    }

                }
                _db.tblSeeker.Add(obj);
                _db.SaveChanges();
                TempData["Message"] = "Registration Succsess";

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
            return RedirectToAction("Login");
        }
        string UploadSeekerProfilePic(IFormFile profilepic)
        {
            string filename = "";
            string path = Path.Combine(_env.WebRootPath, "SeekerProfilePic");
            filename = Guid.NewGuid().ToString().Substring(0, 1) + "_" + profilepic.FileName;
            string filepath = Path.Combine(path, filename);
            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                profilepic.CopyTo(filestream);
            }
            return filename;
        }
        string UploadSeekerCVfilepath(IFormFile CVfilepath)
        {
            string filename = "";
            string path = Path.Combine(_env.WebRootPath, "SeekerCVFile");
            filename = Guid.NewGuid().ToString().Substring(0, 1) + "_" + CVfilepath.FileName;
            string filePath = Path.Combine(path, filename);
            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                CVfilepath.CopyTo(filestream);
            }
            return filename;
        }

        public IActionResult Show_Jobs()
        {

            var jobslist = _db.tblJobs.Where(a => a.LastApplyDate > System.DateTime.Now).ToList();
            return View(jobslist);
        }
        public IActionResult Apply(int id)
        {
            try
            {
                string SeekerEmail = HttpContext.Session.GetString("useremailID");
                var Applied = _db.tblApply.Where(a => a.JobID == id && a.JobSeekerEmail == SeekerEmail).FirstOrDefault();
                if (Applied == null)
                {
                    Apply obj = new Apply();
                    obj.JobID = id;
                    obj.JobSeekerEmail = SeekerEmail;

                    obj.AppliedDate = System.DateTime.Now;
                    _db.tblApply.Add(obj);
                    _db.SaveChanges();
                    TempData["Message"] = "Applied Succsessful";

                }
                else
                {
                    TempData["Message"] = "Already Applied This Job Post";
                }
            }
            catch
            {
                TempData["Message"] = "Some error Occured";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit()
        {
            string email = HttpContext.Session.GetString("useremailID");
            var row = _db.tblSeeker.Where(a => a.Email == email).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public IActionResult Edit(Seeker obj)
        {
            try
            {
                _db.Entry(obj).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["Message"] = "Updated Your Profile";
            }
            catch
            {
                TempData["Message"] = "Error Occured";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
             
        }
        
    }
}

