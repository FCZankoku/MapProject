namespace ACP.DAL.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MapContext : DbContext
    {
        public MapContext()
            : base("name=MapContext")
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<Subdivision> Subdivision { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Latitude)
                .HasPrecision(38, 8);

            modelBuilder.Entity<Address>()
                .Property(e => e.Longitude)
                .HasPrecision(38, 8);
        }
    }
}
