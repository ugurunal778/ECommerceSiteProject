using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSiteProject.WebUI.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {

        }

        public System.Data.Entity.DbSet<ECommerceSiteProject.WebUI.Identity.ApplicationRole> IdentityRoles { get; set; }

        public System.Data.Entity.DbSet<ECommerceSiteProject.WebUI.Identity.ApplicationUser> ApplicationUsers { get; set; }
    }
}