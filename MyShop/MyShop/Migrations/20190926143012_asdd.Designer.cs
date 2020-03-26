﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyShop.Data;

namespace MyShop.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20190926143012_asdd")]
    partial class asdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyShop.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("MyShop.Data.Models.Img", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("path");

                    b.HasKey("id");

                    b.ToTable("img");
                });

            modelBuilder.Entity("MyShop.Data.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("available");

                    b.Property<int>("categoryID");

                    b.Property<string>("desc")
                        .HasMaxLength(1000);

                    b.Property<bool>("favourite");

                    b.Property<int>("imgID");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<double>("price");

                    b.Property<string>("uom")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.HasIndex("categoryID");

                    b.HasIndex("imgID");

                    b.ToTable("item");
                });

            modelBuilder.Entity("MyShop.Data.Models.Login", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("sessionID");

                    b.Property<DateTime>("time");

                    b.Property<int?>("userid");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("login");
                });

            modelBuilder.Entity("MyShop.Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(240);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(90);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("orderTime");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("MyShop.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("itemID");

                    b.Property<int>("orderID");

                    b.Property<double>("price");

                    b.Property<long>("quantity");

                    b.HasKey("id");

                    b.HasIndex("itemID");

                    b.HasIndex("orderID");

                    b.ToTable("orderDetail");
                });

            modelBuilder.Entity("MyShop.Data.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("MyShop.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("itemid");

                    b.Property<double>("price");

                    b.Property<long>("quantity");

                    b.Property<string>("shopCartID");

                    b.HasKey("id");

                    b.HasIndex("itemid");

                    b.ToTable("shopCartItem");
                });

            modelBuilder.Entity("MyShop.Data.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("roleID");

                    b.HasKey("id");

                    b.HasIndex("roleID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("MyShop.Data.Models.Item", b =>
                {
                    b.HasOne("MyShop.Data.Models.Category", "category")
                        .WithMany("items")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyShop.Data.Models.Img", "img")
                        .WithMany("items")
                        .HasForeignKey("imgID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyShop.Data.Models.Login", b =>
                {
                    b.HasOne("MyShop.Data.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");
                });

            modelBuilder.Entity("MyShop.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("MyShop.Data.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("itemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyShop.Data.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyShop.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("MyShop.Data.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("itemid");
                });

            modelBuilder.Entity("MyShop.Data.Models.User", b =>
                {
                    b.HasOne("MyShop.Data.Models.Role", "role")
                        .WithMany("users")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
