
using HRBoost.ContextDb.Abstract;
using HRBoost.ContextDb.Concrete;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Shared.Enums;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HRBoost.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;



        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IEmailService emailService, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;


        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            User u = await _userManager.FindByEmailAsync(email);
            if (u == null)
            {
                return false;
            }
            var result = await _userManager.ConfirmEmailAsync(u, token);
            if (result.Succeeded)
            {
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

        public async Task<bool> RegisterAsync(User user, string role)
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
            u.BusinessId = user.BusinessId;
            u.PhoneNumber = "default";
            u.Status = Shared.Enums.Status.Pending;
            u.CreatedBy = "default";
            u.CreateDate = DateTime.Now;
            u.ModifiedDate = DateTime.Now;
            u.ModifiedBy = "default";
            #endregion

            try
            {
                IdentityResult result = await _userManager.CreateAsync(u, user.Password);
                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(u.UserName);

                    var resultRole = await _userManager.AddToRoleAsync(currentUser, role);
                    sonuc = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Oluşturma işlemleri sırasında bir hata oluştu..." + "(" + ex.Message + ")");
            }
            return sonuc;
        }



        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }


        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Status = user.Status;


                var result = await _userManager.UpdateAsync(existingUser);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }


        public Task<User> GetUserById(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<User> GetUserByMail(string Mail)
        {
            return _userManager.FindByEmailAsync(Mail);
        }

        public async Task<string> GetUserRole(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.First();
        }
        public async Task<bool> DeactivateManagerAndEmployeesAsync(Guid managerId)
        {
            var manager = await _userManager.FindByIdAsync(managerId.ToString());
            if (manager == null)
                return false;

            var employees = await _userManager.Users
                .Where(u => u.BusinessId == manager.BusinessId)
                .ToListAsync();

            foreach (var employee in employees)
            {
                employee.Status = Status.DeActive;
                await _userManager.UpdateAsync(employee);
            }

            manager.Status = Status.DeActive;
            var result = await _userManager.UpdateAsync(manager);
            return result.Succeeded;
        }


        

        public List<User> GetUsersByBusiness(Guid businessId)
        {
            var users = _userManager.Users.Where(x => x.BusinessId == businessId).ToList();
            return (users);
        }
        public async Task<bool> Logout()

        {

           

       
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                return false;
                
            }
            return true;

        }

       
    }
}
    



    
       




