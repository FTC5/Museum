using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL.Context
{
    public class MuseumContext : DbContext
    {
        static MuseumContext()
        {
            Database.SetInitializer<MuseumContext>(new DropCreateDBOnModelChanged());
        }
        public MuseumContext(string connectionString = "MuseumContext") : base(connectionString)
        {

        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomExcursion> CustomExcursions { get; set; }
        public virtual DbSet<ExcursionsSchedule> ExcursionsSchedules { get; set; }
        public virtual DbSet<Exposition> Exposition { get; set; }
        public virtual DbSet<Grafik> Grafik { get; set; }
        public virtual DbSet<Excursion> Excursions { get; set; }
        public virtual DbSet<Guide> Guide { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ExcursionsSchedule>()
                .HasRequired(c => c.Grafik)
                .WithOptional(c => c.ExcursionsSchedule);
            modelBuilder.Entity<ExcursionsSchedule>()
                .HasRequired(c => c.Excursion)
                .WithRequiredPrincipal(c => c.ExcursionsSchedule);
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    } 
    
}
