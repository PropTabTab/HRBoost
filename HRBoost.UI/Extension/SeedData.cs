using HRBoost.Entity;
using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        // Seed roles
        string[] roleNames = { "admin", "personel", "businessmanager" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new Role(roleName));
            }
        }

        // Seed admin user
        var adminEmail = "admin@gmail.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new User
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                PhoneNumber = "default",
                CreatedBy = "default",
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = "default",
            };
            await userManager.CreateAsync(adminUser, "123"); // Set a strong password
            await userManager.AddToRoleAsync(adminUser, "admin");
        }
    }
}