using BlogProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var JsonWriter = JsonConvert.SerializeObject(writers);
            return Json(JsonWriter);
        }
        public IActionResult GetWriterByID(int Wid)
        {
            var findwriter = writers.FirstOrDefault(x => x.Id == Wid);
            var JsonWriter = JsonConvert.SerializeObject(findwriter);
            return Json(JsonWriter);
        }

        [HttpPost]

        public IActionResult AddWriter(WriterClass Writer)
        {
            writers.Add(Writer);
            var JsonWriter = JsonConvert.SerializeObject(Writer);
            return Json(JsonWriter);
        }
        public IActionResult UpdateWriter(WriterClass Writer)
        {
            var writer = writers.FirstOrDefault(x => x.Id == Writer.Id);
            writer.Name = Writer.Name;
            var JsonWriter = JsonConvert.SerializeObject(Writer);
            return Json(JsonWriter);
        }
        [HttpPost]
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            ///var JsonWriter = JsonConvert.SerializeObject(Writer);
            return Json(writer);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1, Name="Yavuz"
            },
             new WriterClass
            {
                Id=2, Name="Selim"
            },
              new WriterClass
            {
                Id=3, Name="Göç"
            }
        };

    }
}
