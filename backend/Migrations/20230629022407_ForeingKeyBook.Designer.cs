﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230629022407_ForeingKeyBook")]
    partial class ForeingKeyBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("address_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("Cep")
                        .HasColumnType("integer")
                        .HasColumnName("cep");

                    b.Property<string>("City")
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("country");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Neighbourhood")
                        .HasColumnType("text")
                        .HasColumnName("neighbourhood");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("UF")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("uf");

                    b.HasKey("id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("backend.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("author");

                    b.Property<int>("Edition")
                        .HasColumnType("integer")
                        .HasColumnName("edition");

                    b.Property<bool>("Exchangable")
                        .HasColumnType("boolean")
                        .HasColumnName("exchangable");

                    b.Property<int>("GuardianId")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("language");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("publisher");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("year");

                    b.HasKey("id");

                    b.ToTable("book");
                });

            modelBuilder.Entity("backend.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Conservation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("conservation");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("genre");

                    b.Property<string>("Pages")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("pages");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("price");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rarity");

                    b.HasKey("CategoryId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("backend.Models.Guardian", b =>
                {
                    b.Property<string>("GuardianId")
                        .HasColumnType("text")
                        .HasColumnName("guardian_id");

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("institution_id")
                        .HasColumnType("integer");

                    b.HasKey("GuardianId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("institution_id");

                    b.ToTable("guardian");
                });

            modelBuilder.Entity("backend.Models.Institution", b =>
                {
                    b.Property<int>("InstitutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("institution_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InstitutionId"));

                    b.Property<string>("Moderator_id")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("moderator_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Telephone")
                        .HasColumnType("text")
                        .HasColumnName("telephone");

                    b.HasKey("InstitutionId");

                    b.ToTable("institution");
                });

            modelBuilder.Entity("backend.Models.Guardian", b =>
                {
                    b.HasOne("backend.Models.Book", "book")
                        .WithOne("Guardian")
                        .HasForeignKey("backend.Models.Guardian", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Institution", "Institution")
                        .WithMany("guardians")
                        .HasForeignKey("institution_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");

                    b.Navigation("book");
                });

            modelBuilder.Entity("backend.Models.Book", b =>
                {
                    b.Navigation("Guardian")
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Institution", b =>
                {
                    b.Navigation("guardians");
                });
#pragma warning restore 612, 618
        }
    }
}
