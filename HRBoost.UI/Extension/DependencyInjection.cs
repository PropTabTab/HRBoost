using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;

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


            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService,EmailService>();
            






            return services;
        }



    }
}
