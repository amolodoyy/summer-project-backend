using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using wiki.business.View_Models;
using wiki.data.Entities;
using wiki.business;
using wiki.data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using System;

namespace WikiApp2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpacesController : BaseController
    {
        private wiki.business.Domains.ISpacesServices _spacesServicesDomain;
        public SpacesController(wiki.business.Domains.ISpacesServices service)
        {
            _spacesServicesDomain = service;
        }


        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("userId", Name = "GetSpacesByUID")]
        public IActionResult GetSpacesByUserId(string userId)
        {
            List<SpaceModel> res = _spacesServicesDomain.GetSpacesByUserId(userId);
            if (res != null)
                return Ok(res);
            else
                throw new Exception("spaces not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getAll", Name = "GetAllSpaces")]
        public IActionResult GetSpaces(string userId)
        {
            List<SpaceModel> res = _spacesServicesDomain.GetSpaces(userId);
           
            if (res != null)
                return Ok(res);
            else
                throw new Exception("spaces not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}", Name = "GetSpace")]
        public IActionResult GetSpaceById(int id)
        {
           SpaceModel res = _spacesServicesDomain.GetSpaceById(id);
            if (res != null)
                return Ok(res);
            else
                throw new Exception("spaces not found");
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public Response CreateSpace(SpaceModel s)
        {

            SpaceModel newSpace = _spacesServicesDomain.CreateSpace(s);

            return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
        }


        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public Response DeleteSpace(int id, string userId)
        {
            wiki.data.Enums.HttpCode result = _spacesServicesDomain.DeleteSpace(id, userId);
            switch (result)
            {
                case wiki.data.Enums.HttpCode.NOT_FOUND:
                    throw new Exception("Space could not be found");
                case wiki.data.Enums.HttpCode.FORBIDDEN:
                    throw new Exception("Access denied"); ;
            }
            return new wiki.data.Response { Status = "Success", Message = "Space deleted successfully" };
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public IActionResult EditSpace(SpaceModel s)
        {
            SpaceModel space = _spacesServicesDomain.EditSpace(s);
            if (space != null)
                return Ok(space);
            else
                throw new Exception("spaces not found");
        }
    }
}