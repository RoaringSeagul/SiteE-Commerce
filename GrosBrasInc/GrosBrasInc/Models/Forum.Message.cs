using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Message
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MessageID { get; set; }
        public virtual string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Forum_Message_Author")]
        public virtual ApplicationUser Author { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Forum_Message_MessageBody")]
        public string MessageBody { get; set; }
        public int SujetID { get; set; }
        [ForeignKey("SujetID")]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Forum_Message_ParentSujet")]
        public virtual Sujet ParentSujet { get; set; }
    }
}