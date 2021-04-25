﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OptionsListApp;

namespace OptionsListApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OptionsListApp.Models.MoreOption", b =>
                {
                    b.Property<int>("MoreOptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MoreOptionTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoreOptionID");

                    b.HasIndex("MoreOptionTypeID");

                    b.ToTable("MoreOption");
                });

            modelBuilder.Entity("OptionsListApp.Models.MoreOptionType", b =>
                {
                    b.Property<int>("MoreOptionTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoreOptionTypeID");

                    b.ToTable("MoreOptionType");
                });

            modelBuilder.Entity("OptionsListApp.Models.Value", b =>
                {
                    b.Property<int>("ValueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MoreOptionID")
                        .HasColumnType("int");

                    b.Property<string>("ValueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ValueID");

                    b.HasIndex("MoreOptionID");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("OptionsListApp.Models.MoreOption", b =>
                {
                    b.HasOne("OptionsListApp.Models.MoreOptionType", "MoreOptionType")
                        .WithMany("MoreOptions")
                        .HasForeignKey("MoreOptionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MoreOptionType");
                });

            modelBuilder.Entity("OptionsListApp.Models.Value", b =>
                {
                    b.HasOne("OptionsListApp.Models.MoreOption", "moreOption")
                        .WithMany("Values")
                        .HasForeignKey("MoreOptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("moreOption");
                });

            modelBuilder.Entity("OptionsListApp.Models.MoreOption", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("OptionsListApp.Models.MoreOptionType", b =>
                {
                    b.Navigation("MoreOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
