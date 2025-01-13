using HRBoost.UI.Extension;
using Microsoft.EntityFrameworkCore;
using HRBoost.Services.Concretes;
using Microsoft.AspNetCore.Authentication;
using HRBoost.ContextDb.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Çevre değişkenlerinden bağlantı dizesi al
var serverName = Environment.GetEnvironmentVariable("SERVER_NAME");
var sqlUid = Environment.GetEnvironmentVariable("SQL_UID");
var sqlPwd = Environment.GetEnvironmentVariable("SQL_PWD");

if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(sqlUid) || string.IsNullOrEmpty(sqlPwd))
{
	throw new InvalidOperationException("Çevre değişkenleri eksik! Lütfen SERVER_NAME, SQL_UID ve SQL_PWD değişkenlerini kontrol edin.");
}

var connectionString = $"Server={serverName};" +
					   $"Database=HRBoostDb;" +
					   $"uid={sqlUid};" +
					   $"pwd={sqlPwd};" +
					   "TrustServerCertificate=true";

// Dependency Injection için servisleri ekleyin
DependencyInjection.ProjectServices(builder.Services, builder.Configuration);

// Veritabanı bağlantısı ve DbContext yapılandırması
builder.Services.AddDbContext<BaseContext>(options =>
	options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
		   name: "areas",
		   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		 );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
