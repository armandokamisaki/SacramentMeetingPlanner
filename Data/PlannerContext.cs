using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

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
    }
}
