﻿using HRBoost.Entity;

namespace HRBoost.UI.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection ProjectServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Projeye MVC kullan
            services.AddControllersWithViews();

            //DB organizasyonu bu nesne içinde.
            HRBoost.ContextDb.DependencyInjection.AddIoCContainer(services, configuration);


            //SErvices katmanı LifeCycle


            //services.AddScoped<IUserService, UserService>();
            






            return services;
        }



    }
}
