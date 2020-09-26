using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace WorkStation.Models
{
    public class Register
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to insert you First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Second Name")]
        [Required(ErrorMessage = "You need to insert you Second Name")]
        public string SecondName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must have a Username")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "You must input your real data")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must have an Email")]      
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Email addresses doesn't match")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must have an Password")]
        [StringLength(100, MinimumLength = 12, ErrorMessage = "Password must be between {1} and {0} characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Pasword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Profile Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase imgURL { get; set; }

    }

    public class LogIn
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must have an Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must have an Password")]
        [StringLength(100, MinimumLength = 12, ErrorMessage = "Password must be between {1} and {0} characters")]
        public string Password { get; set; }
    }

    public class Profile
    {
        [DataType(DataType.ImageUrl)]
        public string imgURL { get; set; }

        [DataType(DataType.MultilineText)]
        public string UserBio { get; set; }
        //
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Display(Name = "Languages")]
        public List<Languages> Language { get; set; }

        [Display(Name = "TechnicalLanguages")]
        public List<TechnicalLanguages> TechnicalLanguage { get; set; }

        [Display(Name = "Technologys")]
        public List<Technologys> Technology { get; set; }

        [Display(Name = "Projects")]
        public List<Projects> Project { get; set; }
    }

    public class Projects
    {
        [DataType(DataType.Text)]
        public string TypeProject { get; set; }

        [DataType(DataType.ImageUrl)]
        public string imgClient { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        public int Stars { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }

    public class Languages
    {
        [DataType(DataType.Text)]
        public string Language { get; set; }
    }

    public class TechnicalLanguages
    {
        [DataType(DataType.Text)]
        public string TechnicalLanguage { get; set; }
    }

    public class Technologys
    {
        [DataType(DataType.Text)]
        public string Technology { get; set; }
    }

    public class AddImg
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Photo { get; set; }
        public HttpPostedFileBase PhotoFile { get;set;}
}
}