﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiCoos.Blog.Controllers
{
    public class UserBackStageController : Controller
    {
        // GET: UserBackStage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserInfo()
        {
            return View();
        }

        public ActionResult Editor()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}