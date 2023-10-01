﻿// <auto-generated />
using System;
using GoldTime.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoldTime.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230517011845_DataBase_1.0")]
    partial class DataBase_10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasketWatchesWatch", b =>
                {
                    b.Property<int>("BasketWatchesId")
                        .HasColumnType("int");

                    b.Property<int>("WatchesId")
                        .HasColumnType("int");

                    b.HasKey("BasketWatchesId", "WatchesId");

                    b.HasIndex("WatchesId");

                    b.ToTable("EnrollmentBasket", (string)null);
                });

            modelBuilder.Entity("ComparisonWatchesWatch", b =>
                {
                    b.Property<int>("ComparisonWatchesId")
                        .HasColumnType("int");

                    b.Property<int>("WatchesId")
                        .HasColumnType("int");

                    b.HasKey("ComparisonWatchesId", "WatchesId");

                    b.HasIndex("WatchesId");

                    b.ToTable("EnrollmentComparison", (string)null);
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.BasketWatches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("BasketWatches");
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.ComparisonWatches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("ComparisonWatches");
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformationsNews")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameNews")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PriceOrder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuentityWatchOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.OrdersUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("OrdersUser");
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComparisonWatchesId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrdersUserId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("WatchesBasketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComparisonWatchesId");

                    b.HasIndex("OrdersUserId");

                    b.HasIndex("WatchesBasketId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.Watch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescriptionModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Watches");
                });

            modelBuilder.Entity("OrderOrdersUser", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersUserId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "OrdersUserId");

                    b.HasIndex("OrdersUserId");

                    b.ToTable("EnrollmentOrders", (string)null);
                });

            modelBuilder.Entity("BasketWatchesWatch", b =>
                {
                    b.HasOne("GoldTime.Models.DataBase.Entitys.BasketWatches", null)
                        .WithMany()
                        .HasForeignKey("BasketWatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldTime.Models.DataBase.Entitys.Watch", null)
                        .WithMany()
                        .HasForeignKey("WatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComparisonWatchesWatch", b =>
                {
                    b.HasOne("GoldTime.Models.DataBase.Entitys.ComparisonWatches", null)
                        .WithMany()
                        .HasForeignKey("ComparisonWatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldTime.Models.DataBase.Entitys.Watch", null)
                        .WithMany()
                        .HasForeignKey("WatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GoldTime.Models.DataBase.Entitys.User", b =>
                {
                    b.HasOne("GoldTime.Models.DataBase.Entitys.ComparisonWatches", "ComparisonWatches")
                        .WithMany()
                        .HasForeignKey("ComparisonWatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldTime.Models.DataBase.Entitys.OrdersUser", "OrdersUser")
                        .WithMany()
                        .HasForeignKey("OrdersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldTime.Models.DataBase.Entitys.BasketWatches", "WatchesBasket")
                        .WithMany()
                        .HasForeignKey("WatchesBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComparisonWatches");

                    b.Navigation("OrdersUser");

                    b.Navigation("WatchesBasket");
                });

            modelBuilder.Entity("OrderOrdersUser", b =>
                {
                    b.HasOne("GoldTime.Models.DataBase.Entitys.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldTime.Models.DataBase.Entitys.OrdersUser", null)
                        .WithMany()
                        .HasForeignKey("OrdersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
