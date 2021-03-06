﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XepHang.Web.Models
{
    public class OrderViewModel
    {
        
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public String Username { get; set; }

        public int RoomId { get; set; }
       
        public virtual RoomViewModel Room { set; get; }

        [Required]
        public int ChosenNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string ModifiledBy { get; set; }

        public bool Status { set; get; }
    }
}