using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAPI.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            var adminRole = new IdentityRole<int>
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new IdentityRole<int>
            {
                Id = 2,
                Name = "User",
                NormalizedName = "USER"
            };

            builder.HasData(adminRole, userRole);
        }
    }
}
