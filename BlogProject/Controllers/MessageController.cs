using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessagesManager messagesManager = new MessagesManager(new EfMessagesRepository());
        public IActionResult InBox()
        {
            var values = messagesManager.GetListByWriter(2);
            return View(values);
        }
        


        public IActionResult MessageDetails(int id)
        {
            var Value = messagesManager.GetById(2);
            return View(Value);
        }
    }
}
