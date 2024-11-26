﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutriBase.Logic.DataContext;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    [DbContext(typeof(NutriBaseDbContext))]
    partial class NutriBaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("NutriBase.Logic.Entities.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", "Account");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DurationInMin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NutritionForm")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WriterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("Recipes", "App");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IngredientNumber")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Usage")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int?>("WriterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("ShoppingLists", "App");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.Base.Grocery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KaloriesPer100Gram")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NutritionForm")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProteinPer100Gram")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShoppingListId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SugarPer100Gram")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("Groceries", "Base");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.Base.HouseholdItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Material")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HouseholtItems", "Base");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.Recipe", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Account.User", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.ShoppingList", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Account.User", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.Base.Grocery", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.App.Recipe", null)
                        .WithMany("Groceries")
                        .HasForeignKey("RecipeId");

                    b.HasOne("NutriBase.Logic.Entities.App.ShoppingList", null)
                        .WithMany("Groceries")
                        .HasForeignKey("ShoppingListId");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.Recipe", b =>
                {
                    b.Navigation("Groceries");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.ShoppingList", b =>
                {
                    b.Navigation("Groceries");
                });
#pragma warning restore 612, 618
        }
    }
}
