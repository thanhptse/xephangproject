using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XepHang.Web.Models
{
    public class RoomViewModel
    {
        
        public int RoomId { get; set; }

        public string RoomName { get; set; }
  
        public int DepartmentId { get; set; }

        public virtual DepartmentViewModel Department { set; get; }

        public DateTime CreatedDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string ModifiledBy { get; set; }

        public string Note { get; set; }

        public bool Status { set; get; }

        public IEnumerable<NumberReportViewModel> NumberReport { set; get; }

        public IEnumerable<OrderViewModel> Order { set; get; }
    }
}