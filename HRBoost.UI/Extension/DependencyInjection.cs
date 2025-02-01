using HRBoost.ContextDb.Abstract;
using HRBoost.ContextDb.Concrete;
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
			services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddScoped<IFileTypeService, FileTypeService>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IDocumentService, DocumentService>();





            return services;
        }



    }
}
