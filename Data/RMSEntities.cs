using Data.Accountings;
using Data.AmenitiesBookings;
using Data.Billings;
using Data.Blocks;
using Data.Categorys;
using Data.Citys;
using Data.Countrys;
using Data.Directorys;
using Data.PropertyAdvertisements;
using Data.PropertyAmenitiess;
using Data.PropertyAssetss;
using Data.PropertyDocss;
using Data.PropertyOwnerss;
using Data.PropertyRenteeAgreements;
using Data.PropertyRentees;
using Data.Propertys;
using Data.PropertyVehicles;
using Data.PropertyVehicleTitos;
using Data.PropertyVendorss;
using Data.Reportss;
using Data.Residents;
using Data.Roles;
using Data.Securitys;
using Data.Services;
using Data.States;
using Data.SupportTickets;
using Data.UserRoles;
using Data.Units;
using Data.Users;
using Data.VendorContracts;
using Data.VendorEmployeeDocs;
using Data.VendorEmployeeRoles;
using Data.VendorEmployees;
using Data.VendorEmpRatings;
using Data.VendorInvoiceDetails;
using Data.VendorInvoices;
using Data.Vendors;
using Data.VendorServices;
using Data.Visitors;
using Data.VisitorVisits;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RMSEntities : DbContext
    {
        public RMSEntities() : base("RMSEntities")
        {
            Database.SetInitializer<RMSEntities>(null);
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<AmenitiesBooking> AmenitiesBookings { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Block> Blocks { get; set; }

        public DbSet<Directory> Directorys { get; set; }
        public DbSet<Property> Propertys { get; set; }

        public DbSet<PropertyAdvertisement> PropertyAdvertisements { get; set; }
        public DbSet<PropertyAmenities> PropertyAmenities { get; set; }
        public DbSet<PropertyAssets> PropertyAssets { get; set; }
        public DbSet<PropertyDocs> PropertyDocs { get; set; }
        public DbSet<PropertyOwners> PropertyOwners { get; set; }
        public DbSet<PropertyRenteeAgreement> PropertyRenteeAgreements { get; set; }
        public DbSet<PropertyRentee> PropertyRentees { get; set; }
        public DbSet<PropertyVehicle> PropertyVehicles { get; set; }
        public DbSet<PropertyVehicleTito> PropertyVehicleTitos { get; set; }

        public DbSet<PropertyVendors> PropertyVendors { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Security> Securitys { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorContract> VendorContracts { get; set; }
        public DbSet<VendorEmployee> VendorEmployees { get; set; }
        public DbSet<VendorEmployeeDoc> VendorEmployeeDocs { get; set; }
        public DbSet<VendorEmployeeRole> VendorEmployeeRoles { get; set; }
        public DbSet<VendorEmpRating> VendorEmpRatings { get; set; }
        public DbSet<VendorInvoice> VendorInvoices { get; set; }
        public DbSet<VendorInvoiceDetail> VendorInvoiceDetails { get; set; }
        public DbSet<Domain.Entities.VendorService> VendorServices { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorVisit> VisitorVisits { get; set; }
       
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Citys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RMSEntities>(null);
            modelBuilder.Configurations.Add(new AccountingConfiguration());
            modelBuilder.Configurations.Add(new AmenitiesBookingConfiguration());
            modelBuilder.Configurations.Add(new BillingConfiguration());
            modelBuilder.Configurations.Add(new BlockConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new DirectoryConfiguration());
            modelBuilder.Configurations.Add(new PropertyConfiguration());
            modelBuilder.Configurations.Add(new PropertyAdvertisementConfiguration());
            modelBuilder.Configurations.Add(new PropertyAmenitiesConfiguration());
            modelBuilder.Configurations.Add(new PropertyAssetsConfiguration());
            modelBuilder.Configurations.Add(new PropertyDocsConfiguration());
            modelBuilder.Configurations.Add(new PropertyOwnersConfiguration());
            modelBuilder.Configurations.Add(new PropertyRenteeAgreementConfiguration());
            modelBuilder.Configurations.Add(new PropertyRenteeConfiguration());
            modelBuilder.Configurations.Add(new PropertyVehicleConfiguration());
            modelBuilder.Configurations.Add(new PropertyVehicleTitoConfiguration());
            modelBuilder.Configurations.Add(new PropertyVendorsConfiguration());
            modelBuilder.Configurations.Add(new ReportsConfiguration());
            modelBuilder.Configurations.Add(new ResidentConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SecurityConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new StateConfiguration());
            modelBuilder.Configurations.Add(new SupportTicketConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new VendorConfiguration());
            modelBuilder.Configurations.Add(new VendorContractConfiguration());
            modelBuilder.Configurations.Add(new VendorEmployeeConfiguration());
            modelBuilder.Configurations.Add(new VendorEmployeeDocConfiguration());
            modelBuilder.Configurations.Add(new VendorEmployeeRoleConfiguration());
            modelBuilder.Configurations.Add(new VendorEmpRatingConfiguration());
            modelBuilder.Configurations.Add(new VendorInvoiceConfiguration());
            modelBuilder.Configurations.Add(new VendorInvoiceDetailConfiguration());
            modelBuilder.Configurations.Add(new VendorServiceConfiguration());
            modelBuilder.Configurations.Add(new VisitorConfiguration());
            modelBuilder.Configurations.Add(new VisitorVisitConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    var IsDeleted = TrySetProperty(entity, "IsDeleted", 1);
                }
            }
            return base.SaveChanges();
        }



        private bool TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }


    }
}
