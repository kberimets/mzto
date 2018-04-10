namespace Mzto.DAL
{
    using System.Data.Entity;

    internal partial class MztoContext : DbContext
    {
        public MztoContext()
            : base("name=MztoContext")
        {
            InitDbSet();
        }

        public MztoContext(string connectionString)
            : base(connectionString)
        {
            InitDbSet();
        }

        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<OikCategory> OikCategories { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<ParameterType> ParameterTypes { get; set; }
        public virtual DbSet<PowerCenter> PowerCenters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain>()
                .HasMany(e => e.PowerCenters)
                .WithRequired(e => e.Domain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OikCategory>()
                .Property(e => e.OikLetter)
                .IsFixedLength();

            modelBuilder.Entity<OikCategory>()
                .HasMany(e => e.Parameters)
                .WithRequired(e => e.OikCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParameterType>()
                .HasMany(e => e.Parameters)
                .WithRequired(e => e.ParameterType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PowerCenter>()
                .HasMany(e => e.Parameters)
                .WithRequired(e => e.PowerCenter)
                .WillCascadeOnDelete(false);
        }

        private void InitDbSet()
        {
            Domains = Set<Domain>();
            Parameters = Set<Parameter>();
            PowerCenters = Set<PowerCenter>();
            OikCategories = Set<OikCategory>();
            ParameterTypes = Set<ParameterType>();
        }
    }
}
