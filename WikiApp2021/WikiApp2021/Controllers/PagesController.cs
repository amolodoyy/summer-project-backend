using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wiki.business.View_Models;
using wiki.data.Entities;
using wiki.data;
using Microsoft.AspNetCore.Authorization;
namespace WikiApp2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagesController : BaseController
    {
        private wiki.business.Domains.IPagesServices _pagesServicesDomain;
        public PagesController(wiki.business.Domains.IPagesServices services)
        {

            _pagesServicesDomain = services;
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getAllUsersPages", Name = "GetAllUsersPages")]
        public IActionResult GetUsersPages(string userId)
        {
            List<PageModel> res = _pagesServicesDomain.GetPages(userId);

            if (res != null)
                return Ok(res);
            else
                throw new Exception("pages not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getAll", Name = "GetAllPages")]
        public IActionResult GetAllPages()
        {
            var res = _pagesServicesDomain.GetAllPages(UserId);

            if (res != null)
                return Ok(res);
            else
                throw new Exception("pages not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult GetUserPages(string userId)
        {
            List<PageModel> pages = _pagesServicesDomain.GetUserPages(userId);
            if (pages != null)
                return Ok(pages);
            else
                throw new Exception("pages not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}", Name = "GetPage")]
        public IActionResult GetPageById(int id)
        {
            PageModel res = _pagesServicesDomain.GetPageById(id);
            if (res != null)
                return Ok(res);
            else
                throw new Exception("pages not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public Response CreatePage(PageModel pageModel)
        {
            _pagesServicesDomain.CreatePage(pageModel);

            return new Response() { Status = "Success", Message = "Page was successfully created" };
        }


        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public Response DeletePage(int id, string userId)
        {
            wiki.data.Enums.HttpCode result = _pagesServicesDomain.DeletePage(id, userId);
            switch (result)
            {
                case wiki.data.Enums.HttpCode.NOT_FOUND:
                    throw new Exception("Requested page not found");
                case wiki.data.Enums.HttpCode.FORBIDDEN:
                    throw new Exception("Access denied");
            }
            return new Response { Status = "Success", Message = "Deletion successful" };
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public IActionResult EditPage(PageModel p)
        {
            PageModel page = _pagesServicesDomain.EditPage(p);
            if (page != null)
                return Ok(page);
            else
                throw new Exception("pages not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("EditPageBody")]
        public IActionResult EditPageBody( PageModel body, int pageId)
        {
            var res = _pagesServicesDomain.EditPageBody(body.Body, pageId);
            switch (res)
            {
                case wiki.data.Enums.HttpCode.NOT_FOUND:
                    throw new Exception("pages not found");
                case wiki.data.Enums.HttpCode.OK:
                    return Ok();
                default:
                    throw new Exception("access denied");
            }
        }
    }
}