using HRBoost.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Abstracts
{
	public interface ICurrencyService
	{
		Task<bool> Add(Currency currency);
		List<Currency> GetCurrencies();
		Currency GetCurrency(int index); // You might want to consider using a GUID here
		Currency GetCurrencyById(Guid id);
		Currency GetCurrencyByName(string name);
		void AddCurrency(Currency currency);
		void UpdateCurrency(Currency updatedCurrency);
		void RemoveCurrency(Guid id);
	}
}
