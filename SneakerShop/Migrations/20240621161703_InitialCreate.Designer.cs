﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SneakerShop.Data;

#nullable disable

namespace SneakerShop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240621161703_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SneakerShop.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UsSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("SneakerShop.Models.Sneaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Sneakers");
                });

            modelBuilder.Entity("SneakerShop.Models.SneakerSize", b =>
                {
                    b.Property<int>("SneakerId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("SneakerId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("SneakerSizes");
                });

            modelBuilder.Entity("SneakerShop.Models.SneakerSize", b =>
                {
                    b.HasOne("SneakerShop.Models.Size", "Size")
                        .WithMany("SneakerSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SneakerShop.Models.Sneaker", "Sneaker")
                        .WithMany("SneakerSizes")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Size");

                    b.Navigation("Sneaker");
                });

            modelBuilder.Entity("SneakerShop.Models.Size", b =>
                {
                    b.Navigation("SneakerSizes");
                });

            modelBuilder.Entity("SneakerShop.Models.Sneaker", b =>
                {
                    b.Navigation("SneakerSizes");
                });
#pragma warning restore 612, 618
        }
    }
}
