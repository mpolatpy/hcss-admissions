using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.SchoolYears.Any())
            {
                List<SchoolYear> schoolYears = new List<SchoolYear>
                {
                    new SchoolYear
                    {
                        IsActiveYear = true,
                        SchoolYearName = "21-22",
                        DisplayOnForm = true,
                        FormLabel = "21-22 (Current School Year)"
                    },
                    new SchoolYear
                    {
                        IsActiveYear = false,
                        SchoolYearName = "22-23",
                        DisplayOnForm = true,
                        FormLabel = "22-23 (Upcoming School Year)"
                    },
                };
                await context.SchoolYears.AddRangeAsync(schoolYears);
            }

            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    UserName="mpolat@hampdencharter.org", 
                    Email="mpolat@hampdencharter.org",
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");

                var role = new IdentityRole("superadmin");
                var result = await roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    Console.WriteLine("Adding Role superadmin");
                    await userManager.AddToRoleAsync(user, "superadmin");
                }
                else{
                    Console.WriteLine("Failed Adding Role superadmin");
                }
                
            }

            if (!context.Schools.Any())
            {
                List<School> schools = new List<School>
                {
                    new School
                    {
                        SchoolName = "HCSS East",

                    },
                    new School
                    {
                        SchoolName = "HCSS West",

                    }
                };

                await context.Schools.AddRangeAsync(schools);
            }

            await context.SaveChangesAsync();
        }
    }
}