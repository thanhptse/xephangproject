using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepHang.Model.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; } 

        [Required]
        [MaxLength(50)]
        public string RoomName { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { set; get; }

        public DateTime? CreatedDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string ModifiledBy { get; set; }

        public string Note { get; set; }

        [Required]
        public bool Status { set; get; }

        public IEnumerable<NumberReport> NumberReport { set; get; }

        public IEnumerable<Order> Order{ set; get; }

    }
}
