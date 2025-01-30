using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class DebitService: BaseServices<Debit>, IDebitService
    {
        public DebitService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
    }
}
