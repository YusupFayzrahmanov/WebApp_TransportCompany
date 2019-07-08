﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_TransportCompany.Data;

namespace WebApp_TransportCompany.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<int>("DriverStatus");

                    b.Property<string>("FirstPhone");

                    b.Property<string>("IdentityId");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("SecondPhone");

                    b.Property<string>("Surname");

                    b.Property<int?>("TatneftCardId");

                    b.Property<int?>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("TatneftCardId");

                    b.HasIndex("TruckId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.DriverTruckHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DriverId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TruckId");

                    b.ToTable("DriverTrucksHistory");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DriverId");

                    b.Property<string>("Principle");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TruckId");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.GuestMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("ImagePath");

                    b.Property<string>("MessageText")
                        .IsRequired();

                    b.Property<bool>("Published");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("GuestMessages");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CargoWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CompanyName");

                    b.Property<string>("DepPoint");

                    b.Property<decimal>("Distance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DriverId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("EndPoint");

                    b.Property<bool>("IsPaid");

                    b.Property<string>("Note");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("State");

                    b.Property<int?>("TruckId");

                    b.Property<int>("TypeOfCargo");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TruckId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RefuelingCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GasStation");

                    b.Property<decimal>("Liters")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RefuelDate");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("TruckId");

                    b.ToTable("RefuelingsCheck");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RefuelingReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DriverId");

                    b.Property<int>("GasStation");

                    b.Property<decimal>("Liters")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RefuelDate");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TruckId");

                    b.ToTable("RefuelingReports");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RefuelingSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Liters")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RefuelDate");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("TruckId");

                    b.ToTable("RefuelingsSensor");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Repair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("Description");

                    b.Property<int?>("DriverId");

                    b.Property<bool>("Guarantee");

                    b.Property<DateTime?>("GuaranteeDeadline");

                    b.Property<string>("Name");

                    b.Property<int?>("PreviousRepairId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RepairDate");

                    b.Property<int?>("RepairTypeId");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("PreviousRepairId");

                    b.HasIndex("RepairTypeId");

                    b.HasIndex("TruckId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RepairType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityId");

                    b.Property<decimal>("KilometersResource");

                    b.Property<string>("Name");

                    b.Property<int>("TimeResourceMonth");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("RepairTypes");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<decimal>("ArrivalMileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ArrivalRemainderFuel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AverageFuelConsumption");

                    b.Property<decimal>("AverageFuelPrice");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<decimal>("DepartureMileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DepartureRemainderFuel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DriverId");

                    b.Property<string>("Note");

                    b.Property<decimal>("ReceivedMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SpentMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TruckId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description");

                    b.Property<int>("DriverId");

                    b.Property<DateTime>("EndPeriod");

                    b.Property<string>("Note");

                    b.Property<DateTime>("OperationDate");

                    b.Property<int>("PaymentMethod");

                    b.Property<DateTime>("StartPeriod");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WrittenOff")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.TatneftCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("IdentityId");

                    b.Property<string>("Note");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("TatneftCards");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Condition");

                    b.Property<int>("IdentityId");

                    b.Property<string>("IdentityId1");

                    b.Property<bool>("IsActual");

                    b.Property<decimal>("MaxSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("RegistrationCertificate");

                    b.Property<int>("Status");

                    b.Property<int?>("TatneftCardId");

                    b.Property<string>("TrailerLicState");

                    b.Property<string>("TruckLicState");

                    b.Property<int>("Type");

                    b.Property<decimal>("WeightLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("YearOfIssue");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId1");

                    b.HasIndex("TatneftCardId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Wheel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BreakdownDate");

                    b.Property<int>("Condition");

                    b.Property<decimal>("CurrentMileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InstallationDate");

                    b.Property<bool>("IsUsed");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<int>("Place");

                    b.Property<int?>("PreviousWheelId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("PreviousWheelId");

                    b.HasIndex("TruckId");

                    b.ToTable("Wheels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Driver", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("WebApp_TransportCompany.Models.TatneftCard", "TatneftCard")
                        .WithMany("Drivers")
                        .HasForeignKey("TatneftCardId");

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("Drivers")
                        .HasForeignKey("TruckId");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.DriverTruckHistory", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("TruckHistories")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Fine", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("Fines")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("Fines")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Order", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("Orders")
                        .HasForeignKey("DriverId");

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("Orders")
                        .HasForeignKey("TruckId");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RefuelingCheck", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("RefuelingChecks")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RefuelingReport", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("RefuelingReports")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("RefuelingReports")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RefuelingSensor", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("RefuelingSensors")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Repair", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("Repairs")
                        .HasForeignKey("DriverId");

                    b.HasOne("WebApp_TransportCompany.Models.Repair", "PreviousRepair")
                        .WithMany()
                        .HasForeignKey("PreviousRepairId");

                    b.HasOne("WebApp_TransportCompany.Models.RepairType", "RepairType")
                        .WithMany()
                        .HasForeignKey("RepairTypeId");

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("Repairs")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.RepairType", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Report", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("Reports")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("Reports")
                        .HasForeignKey("TruckId");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Salary", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Driver", "Driver")
                        .WithMany("Salaries")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.TatneftCard", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Truck", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId1");

                    b.HasOne("WebApp_TransportCompany.Models.TatneftCard", "TatneftCard")
                        .WithMany()
                        .HasForeignKey("TatneftCardId");
                });

            modelBuilder.Entity("WebApp_TransportCompany.Models.Wheel", b =>
                {
                    b.HasOne("WebApp_TransportCompany.Models.Wheel", "PreviousWheel")
                        .WithMany()
                        .HasForeignKey("PreviousWheelId");

                    b.HasOne("WebApp_TransportCompany.Models.Truck", "Truck")
                        .WithMany("Wheels")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
