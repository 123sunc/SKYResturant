using Microsoft.AspNetCore.Identity;

namespace SKYResturant.Models
{
    public class IdentitySeedData
    {
        public static async Task Initialize(SkyDbContext context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            // this is an EF core method that check if the database has been created
            // if it does no action is taken, if not the database and all its schema are created
            context.Database.EnsureCreated();

            // we will add admin and member roles, using 
            string adminRole = "Admin";
            string memberRole = "Member";
            string password4all = "P@55word";
            // look for an existing admin role, if not found then create it
            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // look for an existing member role, if not found then create it
            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }
            // Look for an admin user, if not exist then create with these details
            if (await userManager.FindByNameAsync("admin@ucm.ac.im") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@ucm.ac.im",
                    Email = "admin@ucm.ac.im",
                    PhoneNumber = "06124 648200"
                };
                //if user created then add them to the admin role
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }
            // Look for an member user, if not exist then create with these details
            if (await userManager.FindByNameAsync("member@ucm.ac.im") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "member@ucm.ac.im",
                    Email = "member@ucm.ac.im",
                    PhoneNumber = "06124 648200"
                };
                //if user created then add them to the admin role
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, memberRole);
                }
            }


        }

    }
    }
