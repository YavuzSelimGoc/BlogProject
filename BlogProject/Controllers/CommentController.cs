﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.BlogID = 10;
            commentManager.TAdd(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(//int id
                                                   )
        {
            var Values = commentManager.GetList(//id
                                                );
            return PartialView(Values);
        }
    }
}
