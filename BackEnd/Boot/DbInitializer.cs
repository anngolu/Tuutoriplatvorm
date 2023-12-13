using BackEnd.Auth;
using Microsoft.AspNetCore.Identity;
using tuutoriplatvorm.Model;

namespace backend.Boot
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result)
                roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).Wait();
            if (!roleManager.RoleExistsAsync(UserRoles.Student).Result)
                roleManager.CreateAsync(new IdentityRole(UserRoles.Student)).Wait();
            if (!roleManager.RoleExistsAsync(UserRoles.Tutor).Result)
                roleManager.CreateAsync(new IdentityRole(UserRoles.Tutor)).Wait();

            // Create an admin
            if (userManager.FindByNameAsync("admin1").Result == null)
            {
                IdentityUser user = new()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin1"
                };

                var result = userManager.CreateAsync(user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, UserRoles.Admin).Wait();
                }
            }

            // Create Rest of users
            context.TutorList!.ToList().ForEach(tutor =>
            {
                var username = CreateUser(userManager, (int)tutor.Id!, UserRoles.Tutor);
                if (username != null)
                {
                    tutor.Username = username;
                    context.Update(tutor);
                }
            });

            context.StudentList!.ToList().ForEach(student =>
            {
                var username = CreateUser(userManager, (int)student.Id!, UserRoles.Student);
                if (username != null)
                {
                    student.Username = username;
                    context.Update(student);
                }
            });

            context.SaveChanges();

        }

        private static string? CreateUser(UserManager<IdentityUser> userManager, int id, string role)
        {
            string username = role + id;
            if (userManager.FindByNameAsync(username).Result == null)
            {
                IdentityUser user = new()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = username
                };

                IdentityResult result = userManager.CreateAsync(user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                    return username;
                }
            }
            return null;
        }
    }
}