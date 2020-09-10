﻿// <auto-generated />
using System;
using MainApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MainApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MainApp.Models.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AirportRef")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("AirportId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("MainApp.Models.Runway", b =>
                {
                    b.Property<int>("RunwayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirportId")
                        .HasColumnType("int");

                    b.Property<int?>("LowHeadingDeg")
                        .HasColumnType("int");

                    b.Property<int>("RunwayLengthFt")
                        .HasColumnType("int");

                    b.Property<string>("RunwayMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RunwayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RunwayId");

                    b.HasIndex("AirportId");

                    b.ToTable("Runways");
                });

            modelBuilder.Entity("MainApp.Models.WeatherForecast", b =>
                {
                    b.Property<int>("WeatherForecastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("WeatherForecastId");

                    b.HasIndex("AirportId");

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("MainApp.Models.WeatherReport", b =>
                {
                    b.Property<int>("WeatherReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PredictionDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeatherForecastId")
                        .HasColumnType("int");

                    b.Property<int>("WindDirectionDeg")
                        .HasColumnType("int");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("float");

                    b.HasKey("WeatherReportId");

                    b.HasIndex("WeatherForecastId");

                    b.ToTable("WeatherReports");
                });

            modelBuilder.Entity("MainApp.Models.Runway", b =>
                {
                    b.HasOne("MainApp.Models.Airport", "Airport")
                        .WithMany("Runways")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainApp.Models.WeatherForecast", b =>
                {
                    b.HasOne("MainApp.Models.Airport", "Airport")
                        .WithMany("WeatherForecast")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainApp.Models.WeatherReport", b =>
                {
                    b.HasOne("MainApp.Models.WeatherForecast", "WeatherForecast")
                        .WithMany("WeatherReports")
                        .HasForeignKey("WeatherForecastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}