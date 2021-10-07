using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using wiki.business.View_Models;
using wiki.business.Domains;
using wiki.data;
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
using Microsoft.Extensions.Configuration;

namespace WikiApp2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IEmailService mailService;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, IEmailService mailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.mailService = mailService;
            _configuration = configuration;
        }
        [TypeFilter(typeof(ErrorLogException))]
        [HttpPost("Register")]
        public async Task<Response> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, UserName = model.Email, Path = "1" };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    await mailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Confirm your email: <a href='{callbackUrl}'>link</a>");

                    return new Response { Status = "Success", Message = "To complete registration, check your email and follow the link provided in the letter" }; 
                }
                else
                {
                    throw new Exception("Invalid Data"); ;

                }
            }
            return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
        }
        [TypeFilter(typeof(ErrorLogException))]
        [HttpGet]
        [AllowAnonymous]
        public async Task<Response> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new Exception("Invalid Data"); ;
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Invalid Data"); ;
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            else
                throw new Exception("Invalid Data"); ;
        }

        [TypeFilter(typeof(ErrorLogException))]
        [HttpPost("Login")]
        public async Task<Response> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
               
                
               

               
                if (user != null)
                {

                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        throw new Exception("Invalid Data");
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var encodedJwt = TokenManager.GenerateToken(user);
                    return new Response { Status = "Success",Message = encodedJwt };
                }
                else
                {
                    throw new Exception("Invalid Data"); ;
                }
            }

            throw new Exception("Error"); ;
        }



        [TypeFilter(typeof(ErrorLogException))]
        [HttpPost("LogOff")]

        public async Task<Response> LogOff()
        {
            
            await _signInManager.SignOutAsync();
            return new Response { Status = "Success", Message = "Log out succesfully" };
        }
    }
}
