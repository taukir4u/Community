using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CommunityFinal.Models
{
    public class Gateway : DbContext
    {
        public Gateway() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<DoctorEntry> DoctorEntries { set; get; }
        public DbSet<Medicine> Medicines { set; get; }
        public DbSet<Unit> Units { set; get; }
        public DbSet<Meal> Meals { set; get; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<CreateCenter> CreateCenters { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Upazila> Upazilas { get; set; }
    }
}