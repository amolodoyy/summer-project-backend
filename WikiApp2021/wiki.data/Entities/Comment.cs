using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.data.Entities
{
    public class Comment
    {
        [Key]
        [Column("CommentsId", TypeName = "int")]
        public int Id { get; set; }

        [Column("Body", TypeName = "varchar(max)")]
        [Required]
        public string Body { get; set; }

        [Column("UserId", TypeName = "varchar(36)")]
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }

        [Column("PagesId", TypeName = "int")]
        [Required]
        [ForeignKey("Page")]
        public int PagesId { get; set; }

        [Column("DateCreated", TypeName = "date")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Column("DateEdit", TypeName = "date")]
        [Required]
        public DateTime DateEdit { get; set; }
    }
}