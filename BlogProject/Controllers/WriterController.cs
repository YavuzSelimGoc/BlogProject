using BlogProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
  
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context context = new Context();

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.w = usermail;
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]

        public IActionResult WriterEditProfile()
        {
            var username = User.Identity.Name;
            var WriterId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
            var WriterValues = writerManager.GetById(WriterId);
            return View(WriterValues);
        }
        [HttpPost]

        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                writerManager.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        [HttpGet]        

        public IActionResult WriterAdd()
        {
            
            return View();
        }
        [HttpPost]

        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer w = new Writer();
            if(writer.WriterImage!=null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newimagesname = Guid.NewGuid()+ extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagesname);
                var stream = new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                w.WriterImage = newimagesname;
            }
            w.WriterMail = writer.WriterMail;
            w.WriterID = writer.WriterID;
            w.WriterAbout = writer.WriterAbout;
            w.WriterName = writer.WriterName;
            w.WriterPassword = writer.WriterPassword;
            w.WriterStatus = writer.WriterStatus;
            writerManager.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
