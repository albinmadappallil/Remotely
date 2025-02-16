﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tess.Server.Data;

namespace Tess.Server.Migrations.SqlServer
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20201002214839_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("TessUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tess.Shared.Models.Alert", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeviceID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceID");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("UserID");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Tess.Shared.Models.ApiToken", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("LastUsed")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("Token");

                    b.ToTable("ApiTokens");
                });

            modelBuilder.Entity("Tess.Shared.Models.CommandResult", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommandMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommandResults")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommandText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PSCoreResults")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderConnectionID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetDeviceIDs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("CommandResults");
                });

            modelBuilder.Entity("Tess.Shared.Models.Device", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgentVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("CpuUtilization")
                        .HasColumnType("float");

                    b.Property<string>("CurrentUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceGroupID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Drives")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is64Bit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastOnline")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OSArchitecture")
                        .HasColumnType("int");

                    b.Property<string>("OSDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcessorCount")
                        .HasColumnType("int");

                    b.Property<string>("PublicIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerVerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<double>("TotalMemory")
                        .HasColumnType("float");

                    b.Property<double>("TotalStorage")
                        .HasColumnType("float");

                    b.Property<double>("UsedMemory")
                        .HasColumnType("float");

                    b.Property<double>("UsedStorage")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("DeviceGroupID");

                    b.HasIndex("DeviceName");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Tess.Shared.Models.DeviceGroup", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("DeviceGroups");
                });

            modelBuilder.Entity("Tess.Shared.Models.EventLog", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("EventLogs");
                });

            modelBuilder.Entity("Tess.Shared.Models.InviteLink", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DateSent")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InvitedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResetUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("InviteLinks");
                });

            modelBuilder.Entity("Tess.Shared.Models.Organization", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Tess.Shared.Models.SharedFile", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileContents")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("SharedFiles");
                });

            modelBuilder.Entity("Tess.Shared.Models.UserDevicePermission", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeviceGroupID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceGroupID");

                    b.HasIndex("UserID");

                    b.ToTable("PermissionLinks");
                });

            modelBuilder.Entity("Tess.Shared.Models.TessUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("bit");

                    b.Property<bool>("IsServerAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("OrganizationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TempPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserOptions")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("UserName");

                    b.HasDiscriminator().HasValue("TessUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tess.Shared.Models.Alert", b =>
                {
                    b.HasOne("Tess.Shared.Models.Device", "Device")
                        .WithMany("Alerts")
                        .HasForeignKey("DeviceID");

                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("Alerts")
                        .HasForeignKey("OrganizationID");

                    b.HasOne("Tess.Shared.Models.TessUser", "User")
                        .WithMany("Alerts")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Tess.Shared.Models.ApiToken", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("ApiTokens")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.CommandResult", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("CommandResults")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.Device", b =>
                {
                    b.HasOne("Tess.Shared.Models.DeviceGroup", "DeviceGroup")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceGroupID");

                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("Devices")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.DeviceGroup", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("DeviceGroups")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.EventLog", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("EventLogs")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.InviteLink", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("InviteLinks")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.SharedFile", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("SharedFiles")
                        .HasForeignKey("OrganizationID");
                });

            modelBuilder.Entity("Tess.Shared.Models.UserDevicePermission", b =>
                {
                    b.HasOne("Tess.Shared.Models.DeviceGroup", "DeviceGroup")
                        .WithMany("PermissionLinks")
                        .HasForeignKey("DeviceGroupID");

                    b.HasOne("Tess.Shared.Models.TessUser", "User")
                        .WithMany("PermissionLinks")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Tess.Shared.Models.TessUser", b =>
                {
                    b.HasOne("Tess.Shared.Models.Organization", "Organization")
                        .WithMany("TessUsers")
                        .HasForeignKey("OrganizationID");
                });
#pragma warning restore 612, 618
        }
    }
}
