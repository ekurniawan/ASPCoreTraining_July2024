﻿using ASPCoreTraining.DomainEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.DataEF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Benefit> Benefits { get; set; }

        public virtual DbSet<BenefitEmployee> BenefitEmployees { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.Property(e => e.BenefitName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BenefitEmployee>(entity =>
            {
                entity.ToTable("BenefitEmployee");

                entity.HasOne(d => d.Benefit).WithMany(p => p.BenefitEmployees)
                    .HasForeignKey(d => d.BenefitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BenefitEmployee_Benefits");

                entity.HasOne(d => d.Employee).WithMany(p => p.BenefitEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_BenefitEmployee_Employees");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "Unique_Employees").IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.EmployeeIdMasking)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");
            });
        }

    }
}