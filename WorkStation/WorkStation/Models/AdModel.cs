using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkStation.Models
{
    public class GetAds
    {
        public HttpPostedFileBase UserImg { get; set; }
        public string UserName { get; set; }
        public int Stars { get; set; }
        public string AdName { get; set; }
        public string ProjectType { get; set; }
        public string AdDescription { get; set; }
        public HttpPostedFileBase AdImg1 { get; set; }
        public HttpPostedFileBase AdImg2 { get; set; }
        public HttpPostedFileBase AdImg3 { get; set; }
        public double ProjectPrice { get; set; }
    }

   
    public class CreateAd
    {
        [Display(Name = "Ad Name")]
        [Required(ErrorMessage = "You need to insert the Ad Name")]
        public string AdName { get; set; }

        [Display(Name = "Ad Description")]
        [Required(ErrorMessage = "You need to insert the Ad Description")]
        public string AdDescription { get; set; }

        [Display(Name = "Ad Image")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "You need to upload an image")]
        public HttpPostedFileBase AdImg { get; set; }

        [Display(Name = "Project Price")]
        [Required(ErrorMessage = "You need to insert the Project Price")]
        public int ProjectPrice { get; set; }

        [Display(Name = "Project Type")]
        [Required(ErrorMessage = "You need to select the Project Type")]
        public String ProjectType { get; set; }
    }

    public class NewProject
    {
        [Display(Name = "Project Information")]
        [Required(ErrorMessage = "Project Information needed")]
        [StringLength(8000, MinimumLength = 8, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string ProjectInformation { get; set; }
    }
}