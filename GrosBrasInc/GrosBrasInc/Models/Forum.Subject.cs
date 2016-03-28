using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Sujet
    {
        public int SujetID { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectBody { get; set; }
        public virtual IEnumerable<Message> ChildMessages { get; set; }
    }
}