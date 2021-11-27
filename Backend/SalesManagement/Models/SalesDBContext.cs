using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesManagement.Models
{
    public partial class SalesDBContext : DbContext
    {
        public SalesDBContext()
        {
        }

        public SalesDBContext(DbContextOptions<SalesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<Tblrole> Tblrole { get; set; }
        public virtual DbSet<Tbluser> Tbluser { get; set; }
        public virtual DbSet<VisitTbale> VisitTbale { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=MALAVIKAKNAIR\\SQLEXPRESS; Initial Catalog=SalesDB; Integrated security=True");
            }
        }
       */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__263E2DD37A03440A");

                entity.Property(e => e.EmpId).HasColumnName("Emp_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EmployeeR__UserI__29572725");
            });

            modelBuilder.Entity<Tblrole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__TBLROLE__8AFACE1A0F6AA2AA");

                entity.ToTable("TBLROLE");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbluser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__TBLUSER__1788CC4C7E3498E1");

                entity.ToTable("TBLUSER");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Tbluser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_LOGIN");
            });

            modelBuilder.Entity<VisitTbale>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("PK__VisitTba__DB49A428401AA8D6");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("Contact_No")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("Cust_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("Emp_id");

                entity.Property(e => e.InterestProduct)
                    .HasColumnName("Interest_Product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");

                entity.Property(e => e.IsDisabled).HasColumnName("Is_Disabled");

                entity.Property(e => e.VisitDatetime)
                    .HasColumnName("Visit_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasColumnName("Visit_Subject")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.VisitTbale)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__VisitTbal__Emp_i__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
