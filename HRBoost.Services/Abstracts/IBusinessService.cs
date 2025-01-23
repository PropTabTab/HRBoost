using HRBoost.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Abstracts
{
    public interface IBusinessService : IService<Business>
    {

        Task<Business> RegisterBusiness(Business business, string subName);
        
    }
}
