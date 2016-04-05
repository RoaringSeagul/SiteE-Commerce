using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Sujet
    {
        [ScaffoldColumn(false)]
        public int SujetID { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Forum-Subject_SubjectTitle")]
        public string SubjectTitle { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Forum-Subject_SubjectBody")]
        public string SubjectBody { get; set; }
        [ScaffoldColumn(false)]
        public virtual IEnumerable<Message> ChildMessages { get; set; }
    }
}