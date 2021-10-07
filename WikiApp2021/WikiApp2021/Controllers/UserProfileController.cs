using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wiki.data;
using wiki.data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using wiki.business;
using System.Data;
using wiki.business.View_Models;
using wiki.business.Domains;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace WikiApp2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : BaseController
    {
        private UsersContext _context;

        public UserProfileController(UsersContext _context) : base()
        {
            this._context = _context;
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetUsers", Name = "GetUsers ")]
        public IActionResult GetUsers()
        {

            var username = UserName;

            UserProfileServices us = new UserProfileServices(_context);

            var users = us.GetUsers(username);

            if (users != null)
                return Ok(users);
            else
                throw new Exception("Users not found");



        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllUsers", Name = "GetAllUsers ")]
        public IActionResult GetAllUsers()
        {

            var username = UserName;

            UserProfileServices us = new UserProfileServices(_context);

            var users = us.GetAllUsers();

            if (users != null)
                return Ok(users);
            else
                throw new Exception("Users not found");

           



        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public Users GetUser()
        {



                var username = UserName; 

                UserProfileServices us = new UserProfileServices(_context);

                var users = us.GetUser(username);
                if (users != null)
                    return new Users { FirstName = users.FirstName, LastName = users.LastName, Email = users.Email, Path = users.Path, Id = users.Id };
                else
                    throw new Exception("User not found");

           


       
        }

        [TypeFilter(typeof(ErrorLogException))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("SaveChanges")]
        public Response  SaveChanges(UserProfileModel model)
        {
            if (ModelState.IsValid)
            {

                    
                    UserProfileServices us = new UserProfileServices(_context);                      
                    us.SetUsers(model);

                    return new Response { Status = "Success", Message = "SuccessFully Saved" };

                
            }
            throw new Exception("Error,Could not be saved");
        }

    }
}
