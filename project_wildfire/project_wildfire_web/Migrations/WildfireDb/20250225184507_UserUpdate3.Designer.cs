﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using project_wildfire_web.Models;

#nullable disable

namespace project_wildfire_web.Migrations.WildfireDb
{
    [DbContext(typeof(WildfireDbContext))]
    [Migration("20250225184507_UserUpdate3")]
    partial class UserUpdate3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserFireSubscription", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FireId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FireId")
                        .HasName("PK__UserFire__499520EDB6A35324");

                    b.HasIndex("FireId");

                    b.ToTable("UserFireSubscription", (string)null);
                });

            modelBuilder.Entity("UserLocation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "LocationId")
                        .HasName("PK__UserLoca__79F72605BDDE839A");

                    b.HasIndex("LocationId");

                    b.ToTable("UserLocation", (string)null);
                });

            modelBuilder.Entity("project_wildfire_web.Models.FireDatum", b =>
                {
                    b.Property<int>("FireId")
                        .HasColumnType("int");

                    b.Property<Geometry>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<Geometry>("Polygon")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<decimal>("RadiativePower")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("WeatherId")
                        .HasColumnType("int");

                    b.HasKey("FireId")
                        .HasName("PK__FireData__E1DECA144B6D0E6B");

                    b.HasIndex("WeatherId");

                    b.ToTable("FireData");
                });

            modelBuilder.Entity("project_wildfire_web.Models.SavedLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<Geometry>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("LocationId")
                        .HasName("PK__SavedLoc__E7FEA497C6215128");

                    b.ToTable("SavedLocation", (string)null);
                });

            modelBuilder.Entity("project_wildfire_web.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("AspNetIdentityUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Geometry>("UserLocation")
                        .HasColumnType("geography");

                    b.HasKey("UserId")
                        .HasName("PK__User__1788CC4C8002BA03");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("project_wildfire_web.Models.WeatherDatum", b =>
                {
                    b.Property<int>("WeatherId")
                        .HasColumnType("int");

                    b.Property<int>("AirQualityIndex")
                        .HasColumnType("int");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<string>("WindSpeedDirection")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("WeatherId")
                        .HasName("PK__WeatherD__0BF97BF566B917FE");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("UserFireSubscription", b =>
                {
                    b.HasOne("project_wildfire_web.Models.FireDatum", null)
                        .WithMany()
                        .HasForeignKey("FireId")
                        .IsRequired()
                        .HasConstraintName("FK_UserFireSubscription_FireData");

                    b.HasOne("project_wildfire_web.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserFireSubscription_User");
                });

            modelBuilder.Entity("UserLocation", b =>
                {
                    b.HasOne("project_wildfire_web.Models.SavedLocation", null)
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK_UserLocation_SavedLocation");

                    b.HasOne("project_wildfire_web.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserLocation_User");
                });

            modelBuilder.Entity("project_wildfire_web.Models.FireDatum", b =>
                {
                    b.HasOne("project_wildfire_web.Models.WeatherDatum", "Weather")
                        .WithMany("FireData")
                        .HasForeignKey("WeatherId")
                        .HasConstraintName("FK_FireData_WeatherData");

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("project_wildfire_web.Models.WeatherDatum", b =>
                {
                    b.Navigation("FireData");
                });
#pragma warning restore 612, 618
        }
    }
}
