using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.business.View_Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public int PagesId { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
