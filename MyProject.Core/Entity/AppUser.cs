using Microsoft.AspNetCore.Identity;
using System;

namespace MyProject.Core.Entity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Address { get; set; }
        public bool Gender { get; set; }
    }
}