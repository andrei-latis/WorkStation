using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WorkStationDAL;
using System.IO;
using WorkStation.Models;

namespace WorkStation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Register()
        {
            if (Session["Username"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {

            System.IO.Stream stream = model.imgURL.InputStream;
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            if (image.Height > 128 || image.Width > 128)
            {
                return RedirectToAction("RegisteredFailed", "Alert");
            }

            string FullPath = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["ImgPath"] + @"\" + model.Username + Path.GetExtension(model.imgURL.FileName);
            string PathInProject = System.Configuration.ConfigurationManager.AppSettings["ImgPath"] + @"\" + model.Username + Path.GetExtension(model.imgURL.FileName);

            if (ModelState.IsValid)  
            {
                WorkStationDAL.User User = new WorkStationDAL.User();
                if (User.RegisterAcc(model.Username, model.FirstName, model.SecondName, model.Email, PasswordString(model.Password), PathInProject, model.Birthday) != -1)
                {
                    try
                    {
                        model.imgURL.SaveAs(FullPath);
                        Session["Username"] = model.Username;
                    }
                    catch
                    {
                        User.DeletRegister(model.Username);
                        return View("~/Views/Alert/RegisteredFailed.cshtml");
                    }                  
                }
                else
                {
                    return View("~/Views/Alert/RegisteredFailed.cshtml");
                }
                return View("~/Views/Alert/SuccessfullyRegistered.cshtml");
            }

            return View();
        }

        public ActionResult LogIn() //Get
        {
            WorkStationDAL.User User = new WorkStationDAL.User();
            List<WorkStationDAL.User> str = new List<WorkStationDAL.User>();

            if (Session["Username"] != null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult LogIn(string Email, string Password) //Post pk tem Httppost
        {
            if (ModelState.IsValid) //Para ver se esta tudo preenchid sei la crl 
            {
                WorkStationDAL.User User = new WorkStationDAL.User();
                List<WorkStationDAL.User> str = new List<WorkStationDAL.User>();
                str = User.LoginAcc(Email, PasswordString(Password));
                if (str != null)
                {
                    Session["Username"] = str[0].userName;
                    Session["UserLevel"] = str[0].userLevelId;
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    return View("~/Views/Alert/LoginFailed.cshtml");
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            try
            {
                Session.Clear();
            }
            catch
            {
                return View("~/Views/Alert/LogoutFailed.cshtml");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddImg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImg(AddImg Img)
        {
            System.IO.Stream stream = Img.PhotoFile.InputStream;
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            if (image.Height > 128 || image.Width > 128)
            {
                return View("~/Views/Alert/LoginFailed.cshtml");
            }          

            string caminho = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["ImgPath"] + @"\" +Img.PhotoFile.FileName;
            Img.PhotoFile.SaveAs(caminho);

            string path = "1"; // uploadImage(imgfile)

            if (path.Equals("-1"))
            {
                return View("~/Views/Alert/LoginFailed.cshtml");
            }
            else
            {
                AddImg Imgr = new AddImg();
                Imgr.Name = Img.Name;
                Imgr.Photo = Img.Photo;
                Imgr.Price = System.Configuration.ConfigurationManager.AppSettings["ImgPath"].Replace(@"\", "/") +  "/" + Img.PhotoFile.FileName;
                return View("~/Views/Alert/LoginFailed.cshtml");
            }
        }

        public ActionResult Profile()
        {
            if (Session["Username"] != null)
            {
                WorkStationDAL.User User = new WorkStationDAL.User();
                WorkStationDAL.Skills Skills = new WorkStationDAL.Skills();
                WorkStationDAL.Project Project = new WorkStationDAL.Project();

                ViewBag.UserProfile = User.UserProfile(Session["Username"].ToString());
                ViewBag.TechnicalLanguageSkills = Skills.TechnicalLanguageSkills(Session["Username"].ToString());
                ViewBag.TechnologySkills = Skills.TechnologySkills(Session["Username"].ToString());
                ViewBag.LanguageSkills = Skills.LanguageSkills(Session["Username"].ToString());
                ViewBag.ProjectReview = Project.ProjectReview(Session["Username"].ToString());
            }
            else
            {
                return RedirectToAction("LogIn", "User");
            }
            return View();
        }

        private string PasswordString(string password)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(password);

            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }


















        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
    }
}
