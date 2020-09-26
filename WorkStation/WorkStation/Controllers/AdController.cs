using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkStationDAL;
using System.IO;
using WorkStation.Models;
using System.Data;

namespace WorkStation.Controllers
{
    public class AdController : Controller
    {
        // GET: Ad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ad/Details/5
        public ActionResult ShowAds()
        {
            WorkStationDAL.Ads Ads = new WorkStationDAL.Ads();
            List<WorkStationDAL.Ads> str = new List<WorkStationDAL.Ads>();

            str = Ads.Ad("Website");
            ViewBag.AdModel = str;

            return View();
        }

        // GET: Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateAd()
        {
            if (Session["Username"] == null)
            {
               return RedirectToAction("LogIn", "User");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateAd(CreateAd model)
        {
            if (Session["Username"] != null)
            {
                System.IO.Stream stream = model.AdImg.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

                if (image.Height > 330 || image.Width > 128)
                {
                    return RedirectToAction("CreateAdFailed", "Alert");
                }

                string FullPath = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["ImgPath"] + @"\" + model.AdName + Session["Username"] + Path.GetExtension(model.AdImg.FileName);
                string PathInProject = System.Configuration.ConfigurationManager.AppSettings["ImgPath"] + @"\" + model.AdName + Session["Username"] + Path.GetExtension(model.AdImg.FileName);

                WorkStationDAL.Ads CAd = new WorkStationDAL.Ads();
                if (CAd.CreateAd(model.AdName, model.AdDescription, PathInProject, Session["Username"].ToString(), model.ProjectPrice, model.ProjectType) != -1)
                {
                    try
                    {
                        model.AdImg.SaveAs(FullPath);
                    }
                    catch
                    {
                        return View("~/Views/Alert/CreateAdFailed.cshtml");
                    }

                }
                else
                {
                    return View("~/Views/Alert/CreateAdFailed.cshtml");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "User");
            }

            return View();
        }


        [HttpGet]
        public ActionResult NewProject(string IdAd)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            Session["IdAd"] = IdAd;
            return View();
        }

        [HttpPost]
        public ActionResult NewProject(NewProject model)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("LogIn", "User");
            }
            else
            {
                WorkStationDAL.Project Pro = new WorkStationDAL.Project();
                if (Pro.NewProject(Convert.ToInt32(Session["IdAd"]), Session["Username"].ToString(), model.ProjectInformation) != -1)
                {
                    return View("~/Views/Alert/NewProjectCreated.cshtml");
                }
                else
                {
                    return View("~/Views/Alert/ProjectNotCreated.cshtml");
                }
            }
            return View();
        }
    }
}
