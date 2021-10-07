using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace wiki.data.Entities
{
    public class ErrorLog
    {
        [Key]
        [Column("ErrorLogsId", TypeName = "int")]
        public int Id { get; set; }


        [Column("Message", TypeName = "varchar(max)")]
        [Required]
        public string Message { get; set; }


        [Column("StackTrace", TypeName = "varchar(max)")]
        [Required]
        public string StackTrace { get; set; }
    }
}
