using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkStation.Models
{
    public class TechnologySkills
    {
        [Display(Name = "Technology Name")]
        [Required(ErrorMessage = "You need to insert the Technology Name")]
        public string Technology { get; set; }
    }

    public class TechnicalLanguageSkills
    {
        [Display(Name = "Technical Language Name")]
        [Required(ErrorMessage = "You need to insert theTechnical Language Name")]
        public string TechnicalLanguage { get; set; }
    }

    public class LanguageSkills
    {
        [Display(Name = "Language Name")]
        [Required(ErrorMessage = "You need to insert the Language Name")]
        public string Language { get; set; }
    }
}