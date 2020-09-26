using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkStation.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Skills()
        {
            if (Session["Username"] != null)
            {
                WorkStationDAL.Skills Skills = new WorkStationDAL.Skills();

                ViewBag.ViewTechnologySkills = Skills.ViewTechnologySkills();
                ViewBag.ViewTechnicalLanguageSkills = Skills.ViewTechnicalLanguageSkills();
                ViewBag.ViewLanguageSkills = Skills.ViewLanguageSkills();
            }
            else
            {
                return RedirectToAction("LogIn", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Skills(string VTS, string VTLS, string VLS, string DVTS, string DVTLS, string DVLS)
        {
            WorkStationDAL.Skills Skills = new WorkStationDAL.Skills();
            if (VTS != "")
            {
                Skills.TechnologyNewSkill(VTS);
            }

            if (VTLS != "")
            {
                Skills.TechnicalLanguageNewSkill(VTLS);
            }

            if (VLS != "")
            {
                Skills.LanguageNewSkill(VLS);
            }

            if (DVTS != "")
            {
                Skills.DeleteTechnologySkill(DVTS);
            }

            if (DVTLS != "")
            {
                Skills.DeleteTechnicalLanguageSkill(DVTLS);
            }

            if (DVLS != "")
            {
                Skills.DeleteLanguageSkill(DVLS);
            }

            ViewBag.ViewTechnologySkills = Skills.ViewTechnologySkills();
            ViewBag.ViewTechnicalLanguageSkills = Skills.ViewTechnicalLanguageSkills();
            ViewBag.ViewLanguageSkills = Skills.ViewLanguageSkills();
            return View();
        }
    }
}