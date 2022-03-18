using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    
    public class WriterMessageNotification : ViewComponent
    {
        MessagesManager messageManager = new MessagesManager(new EfMessagesRepository());
        public IViewComponentResult Invoke()
        {
            int RevicerMail = 2;
            var Values = messageManager.GetListByWriter(RevicerMail);
            return View(Values);
        }
    }
}
