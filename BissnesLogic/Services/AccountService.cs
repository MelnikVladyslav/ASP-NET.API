using BissnesLogic.Resourses;
using BusinessLogic.DTOs;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task Register(RegisterDTO data)
        {
            var user = new IdentityUser()
            {
                UserName = data.Username,
                PhoneNumber = data.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }
        public async Task Login(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null || !await userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException(ErrorMessage.InvalidCredantials, HttpStatusCode.BadRequest);
            }

            await signInManager.SignInAsync(user, true);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}