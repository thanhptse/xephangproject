using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepHang.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { set; get; }

        
        public string Username { set; get; }

        public int ChosenNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string ModifiledBy { get; set; }

        public bool Status { set; get; }
    }
}
