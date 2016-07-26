using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepHang.Model.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepeartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepeartmentName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        public string ModifiledBy { get; set; }

        public string Note { get; set; }

        public bool Status { set; get; }

        public virtual IEnumerable<Room> Room { set; get; }
    }
}
