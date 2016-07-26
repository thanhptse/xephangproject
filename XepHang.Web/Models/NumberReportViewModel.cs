using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XepHang.Web.Models
{
    public class NumberReportViewModel
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        
        public virtual RoomViewModel Room { set; get; }

        public DateTime OrderDate { get; set; }

        public int CurrentNumbebOrder { get; set; }

        public int TotalNumberOrder { get; set; }
    }
}