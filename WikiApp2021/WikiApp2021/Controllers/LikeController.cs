using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wiki.business.View_Models;
using wiki.data;
using wiki.data.Entities;

namespace WikiApp2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikeController : BaseController
    {
        private wiki.business.Domains.ILikeServices _likeServicesDomain;
        public LikeController(wiki.business.Domains.ILikeServices services)
        {
            _likeServicesDomain = services;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult GetPageLikes(int pageId)
        {
            List<wiki.business.View_Models.LikeModel> likes = new List<wiki.business.View_Models.LikeModel>();
            likes = _likeServicesDomain.GetPageLikes(pageId);
            if (likes is null)
                return NotFound();
            return Ok(likes);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public Response CreateLike(LikeModel pageId)
        {
            wiki.data.Enums.HttpCode result = _likeServicesDomain.CreateLike(pageId.PageId, UserId);
            switch (result)
            {
                case wiki.data.Enums.HttpCode.NOT_FOUND:
                    return new Response { Status = "Not Found", Message = "Requested page not found" };
                case wiki.data.Enums.HttpCode.FORBIDDEN:
                    return new Response { Status = "Forbidden", Message = "Access denied" };
            }
            return new Response { Status = "Success", Message = "Like successful" };
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public Response RemoveLike(int pageId)
        {
            wiki.data.Enums.HttpCode result = _likeServicesDomain.RemoveLike(pageId, UserId);
            switch (result)
            {
                case wiki.data.Enums.HttpCode.NOT_FOUND:
                    return new Response { Status = "Not Found", Message = "Requested page not found" };
                case wiki.data.Enums.HttpCode.FORBIDDEN:
                    return new Response { Status = "Forbidden", Message = "Access denied" };
            }
            return new Response { Status = "Success", Message = "Like removed successfully" };
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("isLiked", Name = "IsPageLiked")]
        public Response IsLiked(int pageId)
        {
            var response = _likeServicesDomain.IsLiked(pageId, UserId);
            if (response)
                return new Response { Status = "True", Message = "True" };
            return new Response { Status = "False", Message = "False" };
        }
    }
}
