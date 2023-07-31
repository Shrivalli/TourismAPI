﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tourismBigbang.Context;

#nullable disable

namespace tourismBigBang.Migrations
{
    [DbContext(typeof(TourismContext))]
    partial class TourismContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tourismBigBang.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("Date");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int");

                    b.Property<int>("PersonLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("Date");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("tourismBigBang.Models.DaySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Daywise")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("SpotId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("PackageId");

                    b.HasIndex("SpotId");

                    b.HasIndex("VehicleId");

                    b.ToTable("DaySchedules");
                });

            modelBuilder.Entity("tourismBigBang.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("tourismBigBang.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FoodDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("tourismBigBang.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("tourismBigBang.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int?>("Days")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int?>("PricePerPerson")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("tourismBigBang.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("tourismBigBang.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("SpotAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpotDuration")
                        .HasColumnType("int");

                    b.Property<string>("SpotName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("tourismBigBang.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("tourismBigBang.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("tourismBigbang.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("tourismBigBang.Models.Booking", b =>
                {
                    b.HasOne("tourismBigBang.Models.Package", null)
                        .WithMany("Bookings")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tourismBigbang.Models.UserInfo", null)
                        .WithMany("Bookings")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("tourismBigBang.Models.DaySchedule", b =>
                {
                    b.HasOne("tourismBigBang.Models.Hotel", null)
                        .WithMany("DaySchedules")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tourismBigBang.Models.Package", null)
                        .WithMany("DaySchedules")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tourismBigBang.Models.Spot", null)
                        .WithMany("DaySchedules")
                        .HasForeignKey("SpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tourismBigBang.Models.Vehicle", null)
                        .WithMany("DaySchedules")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tourismBigBang.Models.Feedback", b =>
                {
                    b.HasOne("tourismBigbang.Models.UserInfo", null)
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("tourismBigBang.Models.Food", b =>
                {
                    b.HasOne("tourismBigBang.Models.Hotel", null)
                        .WithMany("Foods")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tourismBigBang.Models.Hotel", b =>
                {
                    b.HasOne("tourismBigBang.Models.Place", null)
                        .WithMany("Hotel")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tourismBigBang.Models.Package", b =>
                {
                    b.HasOne("tourismBigBang.Models.Place", null)
                        .WithMany("Packages")
                        .HasForeignKey("PlaceId");

                    b.HasOne("tourismBigbang.Models.UserInfo", null)
                        .WithMany("Packages")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("tourismBigBang.Models.Spot", b =>
                {
                    b.HasOne("tourismBigBang.Models.Place", null)
                        .WithMany("Spots")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tourismBigBang.Models.Transaction", b =>
                {
                    b.HasOne("tourismBigBang.Models.Booking", null)
                        .WithMany("Transactions")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tourismBigBang.Models.Booking", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("tourismBigBang.Models.Hotel", b =>
                {
                    b.Navigation("DaySchedules");

                    b.Navigation("Foods");
                });

            modelBuilder.Entity("tourismBigBang.Models.Package", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("DaySchedules");
                });

            modelBuilder.Entity("tourismBigBang.Models.Place", b =>
                {
                    b.Navigation("Hotel");

                    b.Navigation("Packages");

                    b.Navigation("Spots");
                });

            modelBuilder.Entity("tourismBigBang.Models.Spot", b =>
                {
                    b.Navigation("DaySchedules");
                });

            modelBuilder.Entity("tourismBigBang.Models.Vehicle", b =>
                {
                    b.Navigation("DaySchedules");
                });

            modelBuilder.Entity("tourismBigbang.Models.UserInfo", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Feedbacks");

                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
