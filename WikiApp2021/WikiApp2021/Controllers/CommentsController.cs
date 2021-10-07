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
using wiki.business.Domains;
using wiki.data.Enums;
using Microsoft.AspNetCore.Identity;

namespace WikiApp2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : BaseController
    {
        private readonly IEmailService mailService;
        private ICommentServices _commentServicesDomain;
        private wiki.business.Domains.IPagesServices _pagesServicesDomain;
        private readonly UserManager<Users> _userManager;

        public CommentsController(ICommentServices services, IEmailService mailService, IPagesServices Sservices, UserManager<Users> userManager)
        {
            _userManager = userManager;
            _commentServicesDomain = services;
            this.mailService = mailService;
            _pagesServicesDomain = Sservices;
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult GetUserComments(string userId)
        {
            List<CommentModel> comment = _commentServicesDomain.GetUserComments(userId);
            if (comment != null)
                return Ok(comment);
            else
                throw new Exception("comments not found");
        }


        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{pagesid}", Name = "GetComment")]
        public IActionResult GetCommentByPageId(int pageid)
        {
           List<CommentModel>  com = _commentServicesDomain.GetCommentById(pageid);
            if (com != null)
                return Ok(com);
            else
                throw new Exception("comments not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<Response> CreateComment(CommentModel comment)
        {
            _commentServicesDomain.CreateComment(comment);
            int pageid = comment.PagesId;
            PageModel pages = _pagesServicesDomain.GetPageById(pageid);
            string userid = pages.UserId;
            var user = await _userManager.FindByIdAsync(userid);
            string email = user.Email;

            await mailService.SendEmailAsync(email, "You have new comment", "A new comment on one of your pages");
            return new Response() { Status = "Success", Message = "Comment was successfully created" };
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public Response DeleteComment(int id,string UserId)
        {
            HttpCode result = _commentServicesDomain.DeleteComment(id, UserId);
            switch (result)
            {
                case HttpCode.NOT_FOUND:
                    throw new Exception("Requested comment not found");
                case HttpCode.FORBIDDEN:
                    throw new Exception("Access denied");
            }
            return new Response { Status = "Success", Message = "Comment succsefully delete" };
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public IActionResult EditComment(CommentModel com)
        {
            CommentModel comment = _commentServicesDomain.EditComment(com, UserId);
            if (comment != null)
                return Ok(comment);
            else
                throw new Exception("comments not found");
        }
    }
}