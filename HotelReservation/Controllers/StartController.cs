﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservation.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}