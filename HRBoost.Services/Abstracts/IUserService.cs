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
        Task<bool> LoginAsync(User user);
        Task<bool> RegisterAsync(User user);
    }
}
