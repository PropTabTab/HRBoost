using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class BusinessService : BaseServices<Business>, IBusinessService
    {
        public BusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Business> RegisterBusiness(Business business, int subDuration)
        {


            if (business is null)
            {
                return business;
            }
            //MApper - MApster

            
            Business b = new();
            b.BusinessName = business.BusinessName;
            b.SubscriptionId = business.SubscriptionId;
            b.Status = Shared.Enums.Status.Pending;
            b.CreatedBy = "default";
            b.CreateDate = DateTime.Now;
            b.ModifiedDate = DateTime.Now;
            b.BusinessPhone = "placeholder";
            b.ModifiedBy = "default";
            b.SubscriptionStartTime = DateTime.Now;
            b.SubscriptionFinishTime = DateTime.Now.AddMonths(subDuration);
            

            try
            {
                await this.AddAsync(b);
            }
            catch (Exception ex)
            {

                throw new Exception("Oluşturma işlemleri sırasında bir hata oluştu..." + "(" + ex.Message + ")");
            }
            return b;
        }
    }
}
