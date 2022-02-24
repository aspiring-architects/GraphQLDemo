using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.Models
{
    public partial class GraphQLDemoDBContext : DbContext
    {
        //public GraphQLDemoDBContext() //Should not have empty Contructor for Pooled Context
        //{

        //}
        public GraphQLDemoDBContext(DbContextOptions<GraphQLDemoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentResult> StudentResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=KARLPERSONALOFF\\SQLEXPRESS;Database=GraphQLDemoDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentResult>(entity =>
            {
                entity.ToTable("StudentResult");

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentResults)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentRe__Stude__71D1E811");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
