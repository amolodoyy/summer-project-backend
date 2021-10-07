using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using wiki.business.View_Models;
using wiki.data;
using Microsoft.EntityFrameworkCore;

namespace wiki.business.Domains
{
    public class UserProfileServices 
    {

        private UsersContext  _context;
        public UserProfileServices( UsersContext context) : base()
        {
          
            _context = context;
        }
        public  void SetUsers(UserProfileModel model)
        {


                var users =  _context.Users.FirstOrDefault(p => p.Email == model.Email);

                if (model.LastName != null)
                {
                    users.LastName = model.LastName;
                }
                if (model.FirstName != null)
                {
                    users.FirstName = model.FirstName;
                }

                if (model.Path != null)
                {
                    users.Path = model.Path;
                }

                 _context.SaveChanges();

        }

        public  Users GetUser(string Username)
        {




            var user = _context.Users.FirstOrDefault(p => p.Email == Username);



  
                return new Users
                {

                    
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Path = user.Path,
                    Id = user.Id,


                };
            
        }

        public List<Users> GetUsers(string username)
        {



            var users = _context.Users.Where(p => p.Email != username).ToList();



            return users;
        }

        public List<Users> GetAllUsers()
        {



            var users = _context.Users.ToList();



            return users;
        }



    }
}
