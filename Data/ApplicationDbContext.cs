using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Wheel> Wheels { get; set; }

        public DbSet<RefuelingCheck> RefuelingsCheck { get; set; }

        public DbSet<RefuelingSensor> RefuelingsSensor { get; set; }

        public DbSet<RefuelingReport> RefuelingReports { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<DriverTruckHistory> DriverTrucksHistory { get; set; }

        public DbSet<GuestMessage> GuestMessages { get; set; }

        public DbSet<RepairType> RepairTypes { get; set; }

        public DbSet<Fine> Fines { get; set; }

        public DbSet<TatneftCard> TatneftCards { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<Phone>().ToTable("Phone");

        //    //modelBuilder.Entity<Smartphone>().ToTable("Smartphone");
        //    //modelBuilder.Entity<FKPhone>().HasOne


        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
