using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wiki.data.Entities;
using wiki.business.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WikiApp2021.Controllers
{
    public class ErrorLogException : IExceptionFilter
    {
        public readonly wiki.business.Domains.IErrorLogServices _errorServicesDomain;

        public ErrorLogException(wiki.business.Domains.IErrorLogServices Sservice)
        {
            _errorServicesDomain = Sservice;
        }

        public void OnException(ExceptionContext filterContext)
        {
            ErrorLogModel exception = new ErrorLogModel()
            {
                Message = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
            };

            exception = _errorServicesDomain.CreateErrorLog(exception);

            filterContext.ExceptionHandled = true;
        }
    }
}
