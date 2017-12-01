namespace work_togther.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkTogtherContext : DbContext
    {
        public WorkTogtherContext()
            : base("name=WorkTogtherContext")
        {
        }

        public virtual DbSet<admin> admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.login_name)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.login_password)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.real_name)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
