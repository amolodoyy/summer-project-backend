using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace wiki.data.Entities
{
    public class Space
    {
        [Key]
        [Column("SpacesId", TypeName = "int")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        [Required]
        public string Name { get; set; }

        [Column("UserId", TypeName = "varchar(36)")]
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }

        [Column("DateCreated", TypeName = "date")]
        [Required]
        public DateTime DateCreated { get; set; }

    }
}
