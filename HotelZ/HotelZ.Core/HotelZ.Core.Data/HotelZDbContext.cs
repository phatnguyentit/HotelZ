using HotelZ.Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HotelZ.Core.Data
{
    public partial class HotelZDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public HotelZDbContext(DbContextOptions<HotelZDbContext> options)
            : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry).CreatedDateTime = DateTime.Now;
                }
                else if(entry.State == EntityState.Modified)
                {
                    ((BaseEntity)entry).UpdatedDateTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}