﻿using CfjSummit.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CfjSummit.Infrastructure.Contexts
{
    public class CfjContext : DbContext
    {
        public CfjContext(DbContextOptions<CfjContext> options)
            : base(options)
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}