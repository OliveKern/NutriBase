﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutriBase.Logic.DataContext;

#nullable disable

namespace NutriBase.Logic.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20241221112449_EntitiesAdaptation")]
    partial class EntitiesAdaptation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroceryRecipe", b =>
                {
                    b.Property<int>("GroceriesId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesId")
                        .HasColumnType("int");

                    b.HasKey("GroceriesId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("GroceryRecipe");
                });

            modelBuilder.Entity("GroceryShoppingList", b =>
                {
                    b.Property<int>("GroceriesId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListsId")
                        .HasColumnType("int");

                    b.HasKey("GroceriesId", "ShoppingListsId");

                    b.HasIndex("ShoppingListsId");

                    b.ToTable("GroceryShoppingList");
                });

            modelBuilder.Entity("HouseholdItemRecipe", b =>
                {
                    b.Property<int>("HouseholdItemsId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesId")
                        .HasColumnType("int");

                    b.HasKey("HouseholdItemsId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("HouseholdItemRecipe");
                });

            modelBuilder.Entity("HouseholdItemShoppingList", b =>
                {
                    b.Property<int>("HouseholdItemsId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListsId")
                        .HasColumnType("int");

                    b.HasKey("HouseholdItemsId", "ShoppingListsId");

                    b.HasIndex("ShoppingListsId");

                    b.ToTable("HouseholdItemShoppingList");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", "Account");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("CostNotAccurate")
                        .HasColumnType("bit");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int?>("DurationInMin")
                        .HasColumnType("int");

                    b.Property<int>("IngredientNumber")
                        .HasColumnType("int");

                    b.Property<int?>("NutritionForm")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("Valuation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Definition")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Recipes", "App");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CostNotAccurate")
                        .HasColumnType("bit");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoodsNumber")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Usage")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Definition")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingLists", "App");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.Base.Grocery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int?>("KaloriesPer100Gram")
                        .HasColumnType("int");

                    b.Property<int?>("NutritionForm")
                        .HasColumnType("int");

                    b.Property<string>("PackageSize")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProteinPer100Gram")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("SugarPer100Gram")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Definition")
                        .IsUnique();

                    b.ToTable("Groceries", "Base");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.Base.HouseholdItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int?>("Material")
                        .HasColumnType("int");

                    b.Property<string>("PackageSize")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Definition")
                        .IsUnique();

                    b.ToTable("HouseholtItems", "Base");
                });

            modelBuilder.Entity("GroceryRecipe", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Base.Grocery", null)
                        .WithMany()
                        .HasForeignKey("GroceriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriBase.Logic.Entities.App.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroceryShoppingList", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Base.Grocery", null)
                        .WithMany()
                        .HasForeignKey("GroceriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriBase.Logic.Entities.App.ShoppingList", null)
                        .WithMany()
                        .HasForeignKey("ShoppingListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HouseholdItemRecipe", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Base.HouseholdItem", null)
                        .WithMany()
                        .HasForeignKey("HouseholdItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriBase.Logic.Entities.App.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HouseholdItemShoppingList", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Base.HouseholdItem", null)
                        .WithMany()
                        .HasForeignKey("HouseholdItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NutriBase.Logic.Entities.App.ShoppingList", null)
                        .WithMany()
                        .HasForeignKey("ShoppingListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.Recipe", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NutriBase.Logic.Entities.App.ShoppingList", b =>
                {
                    b.HasOne("NutriBase.Logic.Entities.Account.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
