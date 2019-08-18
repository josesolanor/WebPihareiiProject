﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPihare.Data;

namespace WebPihare.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190818193523_initialPihare")]
    partial class initialPihare
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebPihare.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CI");

                    b.Property<int?>("CommisionerId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Observation");

                    b.Property<DateTime>("RegistredDate");

                    b.Property<string>("SecondLastName");

                    b.HasKey("ClientId");

                    b.HasIndex("CommisionerId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("WebPihare.Entities.Commisioner", b =>
                {
                    b.Property<int>("CommisionerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommisionerPassword");

                    b.Property<int>("ContractNumber");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Nic");

                    b.Property<int>("RoleId");

                    b.Property<string>("SecondLastName");

                    b.Property<int>("Telefono");

                    b.HasKey("CommisionerId");

                    b.HasIndex("RoleId");

                    b.ToTable("Commisioner");
                });

            modelBuilder.Entity("WebPihare.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<decimal>("DeparmentPrice");

                    b.Property<int>("DepartmentCode");

                    b.Property<int>("DepartmentStateId");

                    b.Property<int>("DepartmentTypeId");

                    b.Property<int>("NumberBedrooms");

                    b.Property<int>("NumberFloor");

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepartmentStateId");

                    b.HasIndex("DepartmentTypeId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WebPihare.Entities.Departmentstate", b =>
                {
                    b.Property<int>("DepartmentStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentStateDescription");

                    b.Property<string>("DepartmentStateValue");

                    b.HasKey("DepartmentStateId");

                    b.ToTable("Departmentstate");
                });

            modelBuilder.Entity("WebPihare.Entities.Departmenttype", b =>
                {
                    b.Property<int>("DepartmentTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentTypeDescription");

                    b.Property<string>("DepartmentTypeValue");

                    b.HasKey("DepartmentTypeId");

                    b.ToTable("Departmenttype");
                });

            modelBuilder.Entity("WebPihare.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleDescription");

                    b.Property<string>("RoleValue");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WebPihare.Entities.VisitState", b =>
                {
                    b.Property<int>("VisitStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VisitStateValue");

                    b.HasKey("VisitStateId");

                    b.ToTable("VisitState");
                });

            modelBuilder.Entity("WebPihare.Entities.Visitregistration", b =>
                {
                    b.Property<int>("VisitRegistrationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("ClientJson");

                    b.Property<int>("CommisionerId");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Observations");

                    b.Property<int?>("StateVisitStateId");

                    b.Property<DateTime?>("VisitDay");

                    b.HasKey("VisitRegistrationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CommisionerId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("StateVisitStateId");

                    b.ToTable("Visitregistration");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebPihare.Entities.Client", b =>
                {
                    b.HasOne("WebPihare.Entities.Commisioner", "Commisioner")
                        .WithMany("Client")
                        .HasForeignKey("CommisionerId")
                        .HasConstraintName("FK_Client_Commisioner_CommisionerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebPihare.Entities.Commisioner", b =>
                {
                    b.HasOne("WebPihare.Entities.Role", "Role")
                        .WithMany("Commisioner")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Commisioner_Role_RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebPihare.Entities.Department", b =>
                {
                    b.HasOne("WebPihare.Entities.Departmentstate", "DepartmentState")
                        .WithMany("Department")
                        .HasForeignKey("DepartmentStateId")
                        .HasConstraintName("FK_Department_Departmentstate_DepartmentStateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebPihare.Entities.Departmenttype", "DepartmentType")
                        .WithMany("Department")
                        .HasForeignKey("DepartmentTypeId")
                        .HasConstraintName("FK_Department_Departmenttype_DepartmentTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebPihare.Entities.Visitregistration", b =>
                {
                    b.HasOne("WebPihare.Entities.Client", "Client")
                        .WithMany("Visitregistration")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Visitregistration_Client_ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebPihare.Entities.Commisioner", "Commisioner")
                        .WithMany("Visitregistration")
                        .HasForeignKey("CommisionerId")
                        .HasConstraintName("FK_Visitregistration_Commisioner_CommisionerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebPihare.Entities.Department", "Department")
                        .WithMany("Visitregistration")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Visitregistration_Department_DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebPihare.Entities.VisitState", "StateVisitState")
                        .WithMany("Visitregistration")
                        .HasForeignKey("StateVisitStateId")
                        .HasConstraintName("FK_Visitregistration_VisitState_StateVisitStateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
