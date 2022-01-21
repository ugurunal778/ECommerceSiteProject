using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Identity;
using System.Data.Entity;

namespace DAL.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {

        }

        public DbSet<ApplicationRole> IdentityRoles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}