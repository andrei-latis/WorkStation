using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkStation.Controllers
{
    public class AlertController : Controller
    {
        // GET: Alert
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuccessfullyRegistered()
        {
            return View();
        }

        public ActionResult LoginFailed()
        {
            return View();
        }
    }
}