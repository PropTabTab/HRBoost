﻿using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Abstracts
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        Task<bool> LoginAsync(User user);
        Task<bool> RegisterAsync(User user);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<bool> ConfirmEmailAsync(string email, string token); 
    }
}
