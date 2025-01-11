using HRBoost.ContextDb.Abstract;
using HRBoost.ContextDb.Concrete;
using HRBoost.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.ContextDb
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoCContainer(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<BaseContext>(x => x.UseSqlServer($"Server={Environment.GetEnvironmentVariable("SERVER_NAME")};Database=HRBoostDB;uid={Environment.GetEnvironmentVariable("SQL_UID")};pwd={Environment.GetEnvironmentVariable("SQL_PWD")};TrustServerCertificate=true", x => x.MigrationsAssembly("HRBoost.UI")));

            services.AddIdentity<User, Role>(option =>
            {

                option.SignIn.RequireConfirmedEmail = true;
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedAccount = false;
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<BaseContext>().AddDefaultTokenProviders();



            services.AddScoped<IEFContext, BaseContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
