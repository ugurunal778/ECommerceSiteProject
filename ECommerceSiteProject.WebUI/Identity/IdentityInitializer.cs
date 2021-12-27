using ECommerceSiteProject.WebUI.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerceSiteProject.WebUI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roller
            if (!context.Roles.Any(x=>x.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "admin",
                    Description = "admin Rolü"
                };
                manager.Create(role);
            }
            if (!context.Roles.Any(x => x.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "user",
                    Description = "user Rolü"
                };
                manager.Create(role);
            }
            if (!context.Users.Any(x => x.UserName == "ugur778"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() 
                {
                    Name = "Uğur",
                    SurName = "Ünal",
                    UserName = "ugur778",
                    Email = "ugur778@gmail.com"
                };

                manager.Create(user, "0000");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(x => x.UserName == "fatma123"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "fatma",
                    SurName = "Ünal",
                    UserName = "fatma123",
                    Email = "fatma34@gmail.com"
                };

                manager.Create(user, "1234");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);
        }
    }
}