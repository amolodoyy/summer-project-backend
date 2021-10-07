﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wiki.data;

namespace wiki.data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210805181539_LikesMigration")]
    partial class LikesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wiki.data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CommentsId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Body");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date")
                        .HasColumnName("DateCreated");

                    b.Property<DateTime>("DateEdit")
                        .HasColumnType("date")
                        .HasColumnName("DateEdit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<int>("PfgesId")
                        .HasColumnType("int")
                        .HasColumnName("PagesId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("wiki.data.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PagesId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Body");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date")
                        .HasColumnName("DateCreated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentId");

                    b.Property<int>("SpacesId")
                        .HasColumnType("int")
                        .HasColumnName("SpacesId");

                    b.Property<int>("UserEditId")
                        .HasColumnType("int")
                        .HasColumnName("UserEditId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("wiki.data.Entities.Space", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SpacesId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date")
                        .HasColumnName("DateCreated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Spaces");
                });
#pragma warning restore 612, 618
        }
    }
}