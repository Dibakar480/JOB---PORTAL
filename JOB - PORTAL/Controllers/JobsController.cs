using JOB___PORTAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JOB___PORTAL.Controllers
{
    public class JobsController : Controller
    {
        ProjectContext _db;
        public JobsController(ProjectContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            string email = HttpContext.Session.GetString("useremailID");
            if (email == null)
            {
                return RedirectToAction("Login", "Provider");
            }
            else
            {
                var jobslist = _db.tblJobs.Where(a => a.ProviderEmail == email).ToList();
                if (jobslist == null)
                {
                    ViewBag.Message = "No Record Found";
                }
                return View(jobslist);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            //var jobslist = _db.tblJobs.ToList();
            //ViewBag.jobslist = jobslist;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Jobs obj)
        {
            try
            {
                obj.ProviderEmail = HttpContext.Session.GetString("useremailID");
                _db.tblJobs.Add(obj);
                _db.SaveChanges();
                TempData["Message"] = "Create Successful";
            }
            catch
            {
                TempData["Message"] = "Create unsuccessful";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var row =(from text  in _db.tblJobs where text.JobID == id select text).FirstOrDefault();
                _db.tblJobs.Remove(row);
                _db.SaveChanges();
                TempData["Message"] = "Deleted Succsessful";
            }
            catch
            {
                TempData["Message"] = "Deleted UnSuccessful";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var row=(from text in _db.tblJobs where text.JobID==id select text).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public IActionResult Edit(Jobs obj)
        {
            try
            {
                _db.Entry(obj).State=EntityState.Modified;
                _db.SaveChanges();
                TempData["Message"] = "Page Updated";
            }
            catch
            {
                TempData["Message"] = "Error occurd ";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var row=(from text in _db.tblJobs where text.JobID==id select text).FirstOrDefault();
            return View(row);
        }
        public IActionResult ShowApplicant (int id)
        {
            //string SeekerEmail = HttpContext.Session.GetString("useremailID");
            var aplicantList=(from  t2 in _db.tblApply join t3 in _db.tblSeeker on
                              t2.JobSeekerEmail equals t3.Email where t2.JobID == id 
                              select new Seeker
                              {
                                  Email=t3.Email,
                                  Name=t3.Name,
                                  ContactInfo=t3.ContactInfo,
                               
                                  SeekerProfilePic=t3.SeekerProfilePic,
                                  SeekerCVFile=t3.SeekerCVFile,

                              }).ToList();
            return View(aplicantList);
        }
        public IActionResult ShowSeeker()
        {
            var seekerList=_db.tblSeeker.ToList();
            return View(seekerList);
        }
        public IActionResult Your_Profile()
        {
            string email = HttpContext.Session.GetString("useremailID");
            if (email == null)
            {
                TempData["Message"] = "Invalid";
                return RedirectToAction("Login");
            }
            else
            {
                var userprodier = _db.tblProvider.Where(a => a.Email == email).FirstOrDefault();
                return View(userprodier);
            }

        }
        [HttpGet]
        public IActionResult Edit_Profile()
        {
            string email = HttpContext.Session.GetString("useremailID");
            var row = _db.tblProvider.Where(a => a.Email == email).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public IActionResult Edit_Profile(Provider obj)
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
    }
}
