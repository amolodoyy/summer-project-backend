using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.data.Entities
{
    public class Like
    {
        [ForeignKey("PageId")]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
    }
}
