using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.business.View_Models
{
    public class PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public string UserEditId { get; set; }
        public int SpacesId { get; set; }
        public int ParentId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
