using BlogProject.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var WorkBook=new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("Blog Listesi");
                WorkSheet.Cell(1, 1).Value = "BLOG ID";
                WorkSheet.Cell(1, 2).Value = "BLOG ADI";

                int blogcount = 2;
                foreach (var item in GetBlogList())
                {
                    WorkSheet.Cell(blogcount, 1).Value = item.ID;
                    WorkSheet.Cell(blogcount, 2).Value = item.BlogName;
                    blogcount++;
                }
                using (var stream=new MemoryStream())
                {
                    WorkBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","BlogList1.xlsx");
                }
            }
               
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel> { new BlogModel { ID=1,BlogName="ANANA GİRİŞ"}
            , new BlogModel { ID=2,BlogName="zazaza GİRİŞ"},
             new BlogModel { ID=3,BlogName="AsasaNANA GİRİŞ"}

            };
            return blogModels;
                
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var WorkSheet = WorkBook.Worksheets.Add("Blog Listesi");
                WorkSheet.Cell(1, 1).Value = "BLOG ID";
                WorkSheet.Cell(1, 2).Value = "BLOG ADI";

                int blogcount = 2;
                foreach (var item in GetBlogList())
                {
                    WorkSheet.Cell(blogcount, 1).Value = item.ID;
                    WorkSheet.Cell(blogcount, 2).Value = item.BlogName;
                    blogcount++;
                }
                using (var stream = new MemoryStream())
                {
                    WorkBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogList1.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTittleList()
        {
            List<BlogModel2> blogModels = new List<BlogModel2>();
            using (var c= new Context())
            {
                blogModels = c.Blogs.Select(x => new BlogModel2 { ID=x.BlogID,BlogName=x.BlogTitle}).ToList();
            }
            return blogModels;
        }
        public IActionResult BlogTitleExcel()
        {
            return View();
        }
    }
}
