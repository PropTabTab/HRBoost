using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class RoleService:IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleService(RoleManager<Role> roleManager) 
        {
            _roleManager=roleManager;
        }
        public async Task<bool> Add(string name) 
        {
            if (!await _roleManager.RoleExistsAsync(name))
            {
                var identitResult = await _roleManager.CreateAsync(new Role() { Name = name });
                return identitResult.Succeeded;
            }
            return false;
        }
        public async Task<List<Role>> GetRoles(Expression<Func<Role, bool>> exp)
        {
            return await _roleManager.Roles.Where(exp).ToListAsync();
        }
        public async Task<Role> FindByName(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }
        public async Task<Role> FindById(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<bool> DeleteRole(string id)
        {

            try
            {
                var result = await _roleManager.DeleteAsync(await this.FindById(id));
                return result.Succeeded;
            }
            catch (Exception)
            {


            }

            return false;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<bool> Update(Role role)
        {
            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded;
        }
    }
}

