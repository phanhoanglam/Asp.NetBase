using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Entity;
using System;

namespace MyProject.Data.EntityFrameworkCore
{
    public class MyProjectAppContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<Product> Products { get; set; }

        public MyProjectAppContext(DbContextOptions<MyProjectAppContext> options) : base(options)
        {
        }
    }
}