using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InternDB.Data;

public static class IdentitySeeder
{
    public const string AdminRole = "Admin";
    public const string InternRole = "Intern";

    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var context = scope.ServiceProvider.GetRequiredService<InternDbContext>();
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
        await context.Database.MigrateAsync();

        // Roles
        foreach (var roleName in new[] { AdminRole, InternRole })
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Default admin user
        var adminUserName = "admin";
        var admin = await userManager.FindByNameAsync(adminUserName);
        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = adminUserName,
                Email = "admin@example.com",
                DisplayName = "Administrator"
            };
            var createResult = await userManager.CreateAsync(admin, "Admin@123");
            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, AdminRole);
            }
        }
        else
        {
            // Ensure admin is in Admin role
            if (!await userManager.IsInRoleAsync(admin, AdminRole))
            {
                await userManager.AddToRoleAsync(admin, AdminRole);
            }

            // In Development, reset the admin password to a known value to avoid mismatch
            if (env.IsDevelopment())
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(admin);
                await userManager.ResetPasswordAsync(admin, token, "Admin@123");
            }
        }
    }
}


