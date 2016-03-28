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
        public int MessageID { get; set; }
        public virtual string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser Author { get; set; }
        public string MessageBody { get; set; }
        public int SujetID { get; set; }
        [ForeignKey("SujetID")]
        public virtual Sujet ParentSujet { get; set; }
    }
}