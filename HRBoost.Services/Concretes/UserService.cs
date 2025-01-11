using Azure.Core;
using HRBoost.ContextDb.Abstract;
using HRBoost.ContextDb.Concrete;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        


        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IEmailService emailService , IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            
        
         }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            User u = await _userManager.FindByEmailAsync(email);
            if (u == null) {
                return false;
            }
            var result = await _userManager.ConfirmEmailAsync(u, token);
            if (result.Succeeded) { 
                return true;
            }
            return false;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            string token = "";
            try
            {
                User u = await _userManager.FindByEmailAsync(user.Email);
                token = await _userManager.GenerateEmailConfirmationTokenAsync(u);

            }
            catch (Exception)
            {

                
            }
            return token;
        }

        public async Task<bool> LoginAsync(User user)
        {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            bool sonuc = false;

            if (user is null)
            {
                return sonuc;
            }
            //MApper - MApster

            #region User
            User u = new User();
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.UserName = user.Email;
            u.Email = user.Email;
            u.BusinessName = user.BusinessName;
            u.PhoneNumber = user.PhoneNumber;
            u.Status = Shared.Enums.Status.Pending;
            u.CreatedBy = "default";
            u.CreateDate = DateTime.Now;
            u.ModifiedDate = DateTime.Now;
            u.ModifiedBy = "default";
            #endregion

            try
            {
                IdentityResult result = await _userManager.CreateAsync(u, user.Password);
                //var resultRole = await _userManager.AddToRoleAsync(u, "user");
                if (result.Succeeded)
                {
                    sonuc = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return sonuc;
        }
    }
}
