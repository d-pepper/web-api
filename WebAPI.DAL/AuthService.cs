﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAPI.DAL.Models;

namespace WebAPI.DAL
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(User userModel);
        Task<IdentityUser> FindUser(string userName, string password);
        void Dispose();
    }

    public class AuthService : IDisposable, IAuthService
    {
        private readonly AuthContext _ctx;
        private readonly UserManager<IdentityUser> _userManager; 

        public AuthService()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(User userModel)
        {
            var user = new IdentityUser()
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
