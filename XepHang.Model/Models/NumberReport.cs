using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepHang.Model.Models
{
    public class NumberReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { set; get; }
        
        public DateTime OrderDate { get; set; }

        public int CurrentNumbebOrder { get; set; }

        public int TotalNumberOrder { get; set; }
    }
}
