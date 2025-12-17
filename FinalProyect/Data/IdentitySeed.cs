using FinalProyect.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProyect.Data;
public static class IdentitySeed
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        if (!await roleManager.RoleExistsAsync("Tesorera"))
            await roleManager.CreateAsync(new IdentityRole("Tesorera"));

        var adminEmail = "admin@gmail.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, "Admin123!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        var tesoreraEmail = "tesorera@gmail.com";
        var tesoreraUser = await userManager.FindByEmailAsync(tesoreraEmail);

        if (tesoreraUser == null)
        {
            tesoreraUser = new ApplicationUser
            {
                UserName = tesoreraEmail,
                Email = tesoreraEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(tesoreraUser, "Tesorera123!");
            await userManager.AddToRoleAsync(tesoreraUser, "Tesorera");
        }
    }
}

