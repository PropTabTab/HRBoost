using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
	public class CurrencyService:ICurrencyService
	{
		private readonly List<Currency> currencies;
		public async Task<bool> Add(Currency currency)
		{
			if (currency == null)
			{
				throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");
			}

			await Task.Delay(100);

			if (currencies.Any(c => c.Name == currency.Name))
			{
				return false; 
			}

			currencies.Add(currency);
			return true; 
		}
		public CurrencyService(List<Currency> initialCurrencies = null)
		{
			currencies = initialCurrencies ?? new List<Currency>();
		}

		public List<Currency> GetCurrencies()
		{
			return currencies;
		}

		public Currency GetCurrency(int index)
		{
			if (index < 0 || index >= currencies.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index), "Invalid currency index.");
			}
			return currencies[index];
		}

		public Currency GetCurrencyById(Guid id)
		{
			return currencies.FirstOrDefault(c => c.Id == id)
				   ?? throw new KeyNotFoundException($"Currency with ID {id} not found.");
		}

		public Currency GetCurrencyByName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Currency name cannot be null or empty.", nameof(name));
			}

			return currencies.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
				   ?? throw new KeyNotFoundException($"Currency with name '{name}' not found.");
		}

		public void AddCurrency(Currency currency)
		{
			if (currency == null)
			{
				throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");
			}

			if (currencies.Any(c => c.Id == currency.Id))
			{
				throw new InvalidOperationException($"Currency with ID {currency.Id} already exists.");
			}

			currencies.Add(currency);
		}

		// Update an existing currency
		public void UpdateCurrency(Currency updatedCurrency)
		{
			if (updatedCurrency == null)
			{
				throw new ArgumentNullException(nameof(updatedCurrency), "Currency cannot be null.");
			}

			var existingCurrency = GetCurrencyById(updatedCurrency.Id);
			existingCurrency.Name = updatedCurrency.Name;
			existingCurrency.Code = updatedCurrency.Code;
			existingCurrency.ExchangeRate = updatedCurrency.ExchangeRate;
		}

		// Remove a currency by its GUID
		public void RemoveCurrency(Guid id)
		{
			var currency = GetCurrencyById(id);
			currencies.Remove(currency);
		}
	}
}