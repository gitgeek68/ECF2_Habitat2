﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MulhouseHabitat.Models;
using System.IO;


namespace MulhouseHabitat.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }
    }
}