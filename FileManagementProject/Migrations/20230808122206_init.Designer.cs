﻿// <auto-generated />
using System;
using FileManagementProject.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileManagementProject.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230808122206_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FileManagementProject.Entities.Models.Department", b =>
                {
                    b.Property<int?>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentDepartmentId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 0,
                            DepartmentName = "Director"
                        },
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Purchasing Department",
                            ParentDepartmentId = 0
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Purchasing Manager",
                            ParentDepartmentId = 1
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Purchasing Personnel",
                            ParentDepartmentId = 2
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Accounting Department",
                            ParentDepartmentId = 0
                        },
                        new
                        {
                            DepartmentId = 5,
                            DepartmentName = "Accounting Chief",
                            ParentDepartmentId = 4
                        },
                        new
                        {
                            DepartmentId = 6,
                            DepartmentName = "Accounting Personnel",
                            ParentDepartmentId = 5
                        },
                        new
                        {
                            DepartmentId = 7,
                            DepartmentName = "Sales Department",
                            ParentDepartmentId = 0
                        },
                        new
                        {
                            DepartmentId = 8,
                            DepartmentName = "Sales Chief",
                            ParentDepartmentId = 7
                        },
                        new
                        {
                            DepartmentId = 9,
                            DepartmentName = "Sales Personnel",
                            ParentDepartmentId = 8
                        });
                });

            modelBuilder.Entity("FileManagementProject.Entities.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeManagerId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeePassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DepartmentId = 0,
                            EmployeeEmail = "enes_bykbss@hotmail.com",
                            EmployeeFirstName = "Enes",
                            EmployeeLastName = "Büyükbaş",
                            EmployeeManagerId = 0,
                            EmployeePassword = "1234"
                        },
                        new
                        {
                            EmployeeId = 2,
                            DepartmentId = 2,
                            EmployeeEmail = "enes_buyukbas@hotmail.com",
                            EmployeeFirstName = "Erhan",
                            EmployeeLastName = "Büyük",
                            EmployeePassword = "12345"
                        },
                        new
                        {
                            EmployeeId = 3,
                            DepartmentId = 3,
                            EmployeeEmail = "beyzayuksel0111@gmail.com",
                            EmployeeFirstName = "Beyza",
                            EmployeeLastName = "Yüksel",
                            EmployeePassword = "123456789"
                        },
                        new
                        {
                            EmployeeId = 4,
                            DepartmentId = 5,
                            EmployeeEmail = "enes_bykbss@hotmail.com",
                            EmployeeFirstName = "Emre",
                            EmployeeLastName = "Büyükbaş",
                            EmployeePassword = "123564"
                        },
                        new
                        {
                            EmployeeId = 5,
                            DepartmentId = 6,
                            EmployeeEmail = "hasanyılmaz@hotmail.com",
                            EmployeeFirstName = "hasan",
                            EmployeeLastName = "yılmaz",
                            EmployeePassword = "1268345"
                        },
                        new
                        {
                            EmployeeId = 6,
                            DepartmentId = 8,
                            EmployeeEmail = "merveyuksel0111@gmail.com",
                            EmployeeFirstName = "merve",
                            EmployeeLastName = "Yüksel",
                            EmployeePassword = "1235456789"
                        },
                        new
                        {
                            EmployeeId = 7,
                            DepartmentId = 9,
                            EmployeeEmail = "halilatakan@hotmail.com",
                            EmployeeFirstName = "halil",
                            EmployeeLastName = "atakan",
                            EmployeePassword = "123487"
                        });
                });

            modelBuilder.Entity("FileManagementProject.Entities.Models.Employee", b =>
                {
                    b.HasOne("FileManagementProject.Entities.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("FileManagementProject.Entities.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
