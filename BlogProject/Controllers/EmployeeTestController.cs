using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class EmployeeTestController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44303/api/Default");
            var JsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ClasseMP>>(JsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult EmployeAdd()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeAdd(ClasseMP classeMP)
        {
            var httpclient = new HttpClient();
            var jsonemployee = JsonConvert.SerializeObject(classeMP);
            StringContent content = new StringContent(jsonemployee, Encoding.UTF8, "application/json");
            var repsonsemessage = await httpclient.PostAsync("https://localhost:44303/api/Default", content);
            if (repsonsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(classeMP);
            }
        }
       

        [HttpGet]
        public async Task<IActionResult> EmployeeUpdate(int id)
        {
            var httpclient = new HttpClient();
            var repsonsemessage = await httpclient.GetAsync("https://localhost:44303/api/Default/" + id);
            if (repsonsemessage.IsSuccessStatusCode)
            {
                var jsonemployee = await repsonsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ClasseMP>(jsonemployee);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeUpdate(ClasseMP classeMP)
        {
            var httpclient = new HttpClient();
            var jsonemployee = JsonConvert.SerializeObject(classeMP);
            var content=  new StringContent(jsonemployee, Encoding.UTF8, "application/json");
            var  repsonsemessage = await httpclient.PutAsync("https://localhost:44303/api/Default/", content);
            if (repsonsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View(classeMP);
        }

        public class ClasseMP
        {
            public int EmployerID { get; set; }
            public string EmployerName { get; set; }
        }

    }
}
