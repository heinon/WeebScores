﻿// <auto-generated />
using System;
using AnimeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimeService.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AnimeServiceDbContext))]
    [Migration("20250318161537_InitialAnime")]
    partial class InitialAnime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnimeService.Domain.Anime.Anime", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Animes", (string)null);
                });

            modelBuilder.Entity("AnimeService.Domain.Anime.Anime", b =>
                {
                    b.OwnsMany("AnimeService.Domain.Anime.Entities.Episode", "Episodes", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("AnimeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("EpisodeNumber")
                                .IsRequired()
                                .HasMaxLength(4)
                                .HasColumnType("nvarchar(4)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("Id");

                            b1.HasIndex("AnimeId");

                            b1.ToTable("Episodes", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AnimeId");
                        });

                    b.OwnsMany("AnimeService.Domain.Anime.ValueObjects.Genre", "Genres", b1 =>
                        {
                            b1.Property<Guid>("AnimeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.HasKey("AnimeId", "Id");

                            b1.ToTable("Genres", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AnimeId");
                        });

                    b.Navigation("Episodes");

                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
