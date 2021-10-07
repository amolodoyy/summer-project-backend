using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.data.Entities
{
    public class UsersEdit
    {
        [Key]
        [Column("UsersEditId", TypeName = "int")]
        public int Id { get; set; }

        [Column("UserId", TypeName = "varchar(36)")]
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }

        [Column("DateEdit", TypeName = "date")]
        [Required]
        public DateTime DateEdit { get; set; }
    }
}
