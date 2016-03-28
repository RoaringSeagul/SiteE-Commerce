﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public virtual string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser User { get; set; }
        public string CardNumber { get; set; }
        public string PaypalUrl { get; set; }

    }
}