using DataBaseSetupV3.Data;
using AttendanceBussiness.DbFirst;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseSetupV3
{
    public static class SeedSystemUserData
    {
        #region snippet

        public static async Task Initialize(IServiceProvider serviceProvider, List<SystemUser> userList,string[] args)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            if(userList.Count()>0)
            {
                foreach (var item in userList)
                {
                    var userPassword = GenerateSecurePassword();
                    var userId = await EnsureUser(userManager, item.UserName, item.Email, userPassword, args);

                    NotifyUser(item.Email, userPassword);
                }
            } 
        }

        private static async Task<string> EnsureUser(UserManager<ApplicationUser> userManager,
                                                     string userName,string email, string userPassword,string[] args)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    MainComId = args[0],
                    IndustryId = args[1],
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true
                };
                Task<IdentityResult> identityResult =  userManager.CreateAsync(user, userPassword);
                if(identityResult.Result.Succeeded)
                {
                    Console.WriteLine("\n[NEW SYSTEM USER] UserName = {0} Password = {1}", userName, userPassword); 
                }
                else
                {
                    Console.WriteLine("\n[CREATE SYSTEM USER] UserName = {0} [FAIL]", userName);
                }
            }

            return user.Id;
        }
        #endregion

        private static string GenerateSecurePassword()
        {
            // Generate a secure password
            return "admin888";
        }

        private static void NotifyUser(string userName, string userPassword)
        {
            // Notify user
        }
    }
}