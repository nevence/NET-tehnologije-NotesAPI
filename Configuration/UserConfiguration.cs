using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAPI.Entities;

namespace NotesAPI.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            var adminUser = new User
            {
                Id = 1,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123!")
            };

            var normalUser = new User
            {
                Id = 2,
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                FirstName = "Normal",
                LastName = "User",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User123!")
            };

            builder.HasData(adminUser, normalUser);
        }
    }
}
