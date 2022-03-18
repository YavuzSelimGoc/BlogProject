using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
   
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();
        public IActionResult Index()
        {
            var Values = blogManager.GetBlogListWithCategory();
            return View(Values);
        }
        public IActionResult BlogReadAll(int id)
        {
            
            ViewBag.id = id;
            var Values = blogManager.GetBlogById(id);
            return View(Values);
        }
        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var WriterId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
            var values=blogManager.GetListWithCategoryByWriter(WriterId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            //var Values = categoryManager.GetList();
            List<SelectListItem> CategoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {Text=x.CategoryName,Value=x.CategoryID.ToString() }).ToList();
            ViewBag.cv = CategoryValue;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var username = User.Identity.Name;
            var WriterId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.BlogStatus = true;
                blog.WriterID = WriterId;
                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            var BlogValue = blogManager.GetById(id);
            blogManager.TDelete(BlogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]

        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> CategoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.cv = CategoryValue;

            var BlogValue = blogManager.GetById(id);
            return View(BlogValue);
        }
        [HttpPost]

        public IActionResult EditBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var WriterId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                
                blog.BlogStatus = true;
                blog.WriterID = WriterId;
                blogManager.TUpdate(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("BlogListByWriter");
        }
            
        
    }
}
