using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.business.Domains
{
    public interface IErrorLogServices
    {
        public View_Models.ErrorLogModel CreateErrorLog(View_Models.ErrorLogModel errorLog);
    }
}
