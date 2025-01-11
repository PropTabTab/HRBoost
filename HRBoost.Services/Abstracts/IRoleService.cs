using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Abstracts
{
    internal interface IRoleService
    {
        Task<bool> Add(string name);
        Task<List<Role>> GetRoles(Expression<Func<Role,bool>>exp);
        Task<List<Role>> GetAll();
        Task<Role>FindByName(string name);
        Task<Role> FindById(string id);
        Task<bool>DeleteRole(string id);
        Task<bool> Update(Role role);

    }
}
