using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
	public class CurrencyService:BaseServices<Currency>, ICurrencyService
	{
		public CurrencyService(IUnitOfWork unitOfWork):base(unitOfWork) 
		{
		
		}


		
	}
}