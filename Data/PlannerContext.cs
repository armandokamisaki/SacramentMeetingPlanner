using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;
using System;
using System.Collections.Generic;

namespace SacramentMeetingPlanner.Data
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options) : base(options)
        {
        }
        public DbSet<Planner> Planner { get; set; }
        public DbSet<Hymn> Hymn { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Speaker> Speaker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planner>().ToTable("Planner");
            modelBuilder.Entity<Hymn>().ToTable("Hymn");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");            
        }
    }

}
