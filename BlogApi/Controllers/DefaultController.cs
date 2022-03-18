using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployerList()
        {
            using var c = new Context();
            var values = c.Employers.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployerAdd(Employer employer)
        {
            using var c = new Context();
            c.Add(employer);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployerGet(int id)
        {
            using var c = new Context();
            var values = c.Employers.ToList().Where(x => x.EmployerID == id);
            //var values = c.Employers.Find(id);
            if (values==null)
            {
                return NotFound();  
            }
            else
            {
                return Ok(values);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult EmployerDelete(int id)
        {
            using var c = new Context();
            var values = c.Employers.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return Ok();
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult EmployerUpdate(Employer employer)
        {
            using var c = new Context();
            var values = c.Find<Employer>(employer.EmployerID);
           
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.EmployerName= employer.EmployerName;
                c.Update(values);
                c.SaveChanges();
                return Ok(values);
            }

        }

    }
}
