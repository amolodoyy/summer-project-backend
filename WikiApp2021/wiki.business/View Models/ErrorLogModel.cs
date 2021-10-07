using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.business.View_Models
{
    public class ErrorLogModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
