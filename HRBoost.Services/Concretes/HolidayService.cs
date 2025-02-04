using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class HolidayService : IHolidayService
    {
        public async Task<List<Holiday>> getHolidays()
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync("https://script.googleusercontent.com/macros/echo?user_content_key=ic9X8eLqASfWPCHpxHUerfCvSJwYgEhNaOzs6pEIKR6jp2Xdm_zhzbt5zq_CZJ-HmHZB2IeKH89McJviZHS2rkdIhUxjMS4lm5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnBJmqZ7aCXgr_T9raHPdKD6FzJhOrtBk09Ompd0XWIbEdnRLihd5L-SribzJCTkISQa9gIUwtEVBJ4l_9wfuv83zfNqxja1jVw&lib=MuYsjupAABHnb8YXhYhaAABxIoJWoTElh");
            string orderJson = await response.Content.ReadAsStringAsync();

            var holidays = JsonConvert.DeserializeObject<List<Holiday>>(orderJson);
            return holidays;
        }
    }
}
