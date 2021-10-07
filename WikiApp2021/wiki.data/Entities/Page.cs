using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.data.Entities
{
    public class Page
    {
        [Key]
        [Column("PagesId", TypeName = "int")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        [Required]
        public string Name { get; set; }


        [Column("Body", TypeName = "varchar(max)")]
        [Required]
        public string Body { get; set; }

        [Column("UserId", TypeName = "varchar(36)")]
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }

        [Column("UserEditId", TypeName = "varchar(36)")]
        [Required]
        [ForeignKey("Users")]
        public string UserEditId { get; set; }

        [Column("ParentId", TypeName = "int")]
        [Required]
        [ForeignKey("Page")]
        public int ParentId { get; set; }

        [Column("SpacesId", TypeName = "int")]
        [Required]
        [ForeignKey("Space")]
        public int SpacesId { get; set; }

        [Column("DateCreated", TypeName = "date")]
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
