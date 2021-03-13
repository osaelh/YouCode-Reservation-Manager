using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouCodeReservation
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var User = new IdentityUser
                {
                    UserName = "Admin@LocalHost.com",
                    Email = "Admin@localhost.com",

                };
                var result = userManager.CreateAsync(User, "Oussama@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(User, "Administrator").Wait();
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var Role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(Role).Result;
            }
            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                var Role = new IdentityRole
                {
                    Name = "Student"
                };
                var result = roleManager.CreateAsync(Role).Result;
            }
        }
    }
}
