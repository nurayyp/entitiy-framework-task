﻿using ConsoleApp1.Constants;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Contexts
{
    internal class AppDBcontext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.DefaultConnection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Teacher>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Student>().Property(x => x.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Group>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Student>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Teacher>().HasQueryFilter(x => x.IsDeleted == false);

        }
    }
}
