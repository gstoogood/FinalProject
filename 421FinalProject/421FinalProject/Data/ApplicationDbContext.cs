﻿using System;
using System.Collections.Generic;
using System.Text;
using FinalProject421.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject421.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destination { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<GenInfo> GenInfo { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Place> Place { get; set; }
    }
}
