using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace XepHang.Web.Models
{
    public class DepartmentViewModel
    {
        public int DepeartmentId { get; set; }

        public string DepeartmentName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string ModifiledBy { get; set; }

        public string Note { get; set; }

        public bool Status { set; get; }

        public virtual IEnumerable<RoomViewModel> Room { set; get; }
    }
}